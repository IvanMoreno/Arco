using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Stacklands
{
    public class BoosterPack : MonoBehaviour
    {
        const int spawnItemsRadius = 4;
        
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
            var whereToSpawnEachCard = RadiusSpawning(cardsToSpawn.Length, center).ToList();

            for (var i = 0; i < whereToSpawnEachCard.Count; i++)
            {
                FindAnyObjectByType<SpaceTime>().SpawnNearbyCard(cardsToSpawn[i], whereToSpawnEachCard[i]);
                await Task.Delay(100);
            }

            Destroy(gameObject);
        }

        static IEnumerable<Vector2> RadiusSpawning(int howManyToSpawn, Vector2 center)
        {
            var centerTweak = center + new Vector2(-0.75f, 1.75f);
            var angleIncrement = 2 * Mathf.PI / howManyToSpawn;
            for (var i = 0; i < howManyToSpawn; i++)
            {
                var firstAngleTheTopOne = (i + 1) * angleIncrement;
                var x = centerTweak.x + spawnItemsRadius * Mathf.Cos(firstAngleTheTopOne);
                var y = centerTweak.y + spawnItemsRadius * Mathf.Sin(firstAngleTheTopOne);
                yield return new Vector2(x, y);
            }
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, spawnItemsRadius);
        }
    }
}