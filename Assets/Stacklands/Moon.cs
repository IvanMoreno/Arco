using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Stacklands
{
    public class Moon : MonoBehaviour
    {
        static IEnumerable<Villager> HungryVillagers => FindObjectsOfType<Villager>().Where(x => x.IsHungry);
        
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
            GetComponent<AudioSource>().Play();
            
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
            
            await ToBePressed(button);

            GetComponent<Image>().fillAmount = 0;
            button.gameObject.SetActive(false);
        }

        async Task ToBePressed(Button button)
        {
            if (GetComponentInChildren<Toggle>().isOn)
                return;
            
            var tcs = new TaskCompletionSource<bool>();
            
            UnityAction unlockTask = () => tcs.TrySetResult(true);
            button.onClick.AddListener(unlockTask);
            await tcs.Task;
            button.onClick.RemoveListener(unlockTask);

            button.GetComponent<AudioSource>().Play();
        }

        static async Task FeedVillagers()
        {
            BreakStacks();
            await FeedAllVillagers();
            await KillHungryVillagers();
        }

        static async Task KillHungryVillagers()
        {
            foreach (var hungryVillager in HungryVillagers)
            {
                await hungryVillager.Die();
            }
        }

        static async Task FeedAllVillagers()
        {
            foreach (var food in FindObjectsOfType<Food>())
            {
                await FeedFirstHungryVillager(food);
            }
        }

        static async Task FeedFirstHungryVillager(Food food)
        {
            if (!HungryVillagers.Any()) 
                return;

            await HungryVillagers.First().Eat();
            food.Consume();
        }

        static void BreakStacks()
        {
            foreach (var stackables in FindObjectsOfType<Stackable>())
            {
                stackables.RemoveFromStack();
            }
        }

        async Task UntilFullMoon()
        {
            while (GetComponent<Image>().fillAmount < 1f)
                await Task.Yield();
        }

        void Update()
        {
            var cycleSeconds = 60f;
            if (Input.GetKeyDown(KeyCode.Space))
                GetComponent<Image>().fillAmount = 0.99f;
            GetComponent<Image>().fillAmount += Time.deltaTime / cycleSeconds;
        }
    }
}