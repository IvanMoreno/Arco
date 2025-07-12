using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Stacklands
{
    public class BoosterPack : MonoBehaviour
    {
        [SerializeField] GameObject[] cardsToSpawn;

        TaskCompletionSource<bool> untilClicked = new();
        
        async void Start()
        {
            await untilClicked.Task;
            await OpenPack();
        }
        
        void OnMouseDown()
        {
            untilClicked.TrySetResult(true);
        }

        async Task OpenPack()
        {
            for (var i = 0; i < cardsToSpawn.Length; i++)
            {
                var card = cardsToSpawn[i];
                Instantiate(card, BelowMe(nTimes: i), Quaternion.identity);
                FindAnyObjectByType<SpaceTime>().SpawnNearby(card, BelowMe(nTimes: i));
                
                await Task.Delay(100);
            }

            Destroy(gameObject);

        }

        Vector3 BelowMe(int nTimes)
        {
            return transform.position + Vector3.down * Card.AssumedSizeAprox.y * (nTimes+1);
        }
    }
}