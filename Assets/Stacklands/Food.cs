using UnityEngine;
using UnityEngine.Assertions;

namespace Stacklands
{
    public class Food : MonoBehaviour
    {
        public bool WasConsumed { get; private set; }
        public void Consume()
        {
            Assert.IsFalse(WasConsumed, "Food was already consumed.");
            
            WasConsumed = true;
            Destroy(gameObject);
        }
    }
}