using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;

namespace Stacklands
{
    public class Villager : MonoBehaviour
    {
        [SerializeField] GameObject corpsePrefab;
        int foodNeeded = 0;
        
        public bool IsHungry => foodNeeded > 0;
        
        public async Task Die()
        {
            Instantiate(corpsePrefab, transform.position + Vector3.one * 0.34f, Quaternion.identity);
            FindAnyObjectByType<SpaceTime>().SpawnNearby(corpsePrefab, transform.position);
            await Task.Delay(312);
            Destroy(gameObject);
        }

        public void BecomeHungry()
        {
            foodNeeded++;
            foodNeeded++;
        }

        public Task Eat()
        {
            Assert.IsTrue(IsHungry);
            foodNeeded--;
            return Task.Delay(234);
        }
    }
}