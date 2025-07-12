using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Stacklands
{
    public class BoosterPack : MonoBehaviour
    {
        const int spawnItemsRadius = 5;
        
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
            var center = transform.position;
            var angleIncrement = 2 * Mathf.PI / cardsToSpawn.Length;
            for (var i = 0; i < cardsToSpawn.Length; i++)
            {
                var angle = (i + 1) * angleIncrement;
                var x = center.x + spawnItemsRadius * Mathf.Cos(angle);
                var y = center.z + spawnItemsRadius * Mathf.Sin(angle);
                FindAnyObjectByType<SpaceTime>().SpawnNearbyCard(cardsToSpawn[i], new Vector2(x, y));
                await Task.Delay(100);
            }

            Destroy(gameObject);
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, spawnItemsRadius);
        }
    }
}