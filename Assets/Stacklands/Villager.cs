using UnityEngine;
using UnityEngine.Assertions;

namespace Stacklands
{
    public class Villager : MonoBehaviour
    {
        int foodNeeded = 0;
        
        public bool IsHungry => foodNeeded > 0;
        
        public void Die()
        {
            GetComponentInChildren<SpriteRenderer>().color = Color.gray;
        }

        public void BecomeHungry()
        {
            foodNeeded++;
            foodNeeded++;
        }

        public void Eat()
        {
            Assert.IsTrue(IsHungry);
            foodNeeded--;
        }
    }
}