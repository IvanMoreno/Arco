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
            Debug.Log("aksdfj");
        }

        async Task OpenPack()
        {
            for (var i = 0; i < cardsToSpawn.Length; i++)
            {
                var card = cardsToSpawn[i];
                Instantiate(card, transform.position + Vector3.down * (i+1), Quaternion.identity);
                
                await Task.Delay(100);
            }

            Destroy(gameObject);

        }
    }
}