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
            await UntilPlayerWantsToFeedVillagers();
            await FeedVillagers();
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

        Task FeedVillagers()
        {
            var villagers = FindObjectsOfType<Villager>(true);
            foreach (var villager in villagers)
            {
                villager.Die();
            }

            return Task.CompletedTask;
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