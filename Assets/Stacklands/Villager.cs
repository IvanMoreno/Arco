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
            FindAnyObjectByType<SpaceTime>().SpawnAt(corpsePrefab, transform.position);
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