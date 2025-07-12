using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Stacklands
{
    public class Moon : MonoBehaviour
    {
        void Awake()
        {
            GetComponent<Image>().fillAmount = 0;
        }
        
        async void Start()
        {
            await Cycle(destroyCancellationToken);
        }

        async Task Cycle(CancellationToken cancellationToken)
        {
            while( !cancellationToken.IsCancellationRequested)
            {
                await UntilFullMoon();
                await EndCycle();
            }
        }

        async Task EndCycle()
        {
            VillagersGetHungry();
            await UntilPlayerWantsToFeedVillagers();
            await FeedVillagers();
        }

        void VillagersGetHungry()
        {
            var villagers = FindObjectsOfType<Villager>(true);
            foreach (var villager in villagers)
            {
                villager.BecomeHungry();
            }
        }

        async Task UntilPlayerWantsToFeedVillagers()
        {
            var button = FindObjectsOfType<Button>(true).Single(x => x.name == "FeedVillagers");
            button.gameObject.SetActive(true);
            var tcs = new TaskCompletionSource<bool>();
            button.onClick.AddListener(() =>
            {
                GetComponent<Image>().fillAmount = 0;
                button.gameObject.SetActive(false);
                button.onClick.RemoveAllListeners();
                tcs.SetResult(true);
            });
            await tcs.Task;
        }

        async Task FeedVillagers()
        {
            var villagers = FindObjectsOfType<Villager>(true);
            foreach (var villager in villagers)
                await FeedOrDie(villager);
        }

        static async Task FeedOrDie(Villager villager)
        {
            var allFood = FindObjectsOfType<Food>();
            foreach (var food in allFood)
            {
                if (!villager.IsHungry)
                    continue;
                
                await villager.Eat();
                food.Consume();
            }
            
            if (villager.IsHungry)
                await villager.Die();
        }

        async Task UntilFullMoon()
        {
            while (GetComponent<Image>().fillAmount < 1f)
                await Task.Yield();
        }

        void Update()
        {
            var cycleSeconds = 60f;
            if (Input.GetKey(KeyCode.Space))
                cycleSeconds /= 50;
            GetComponent<Image>().fillAmount += Time.deltaTime / cycleSeconds;
        }
    }
}