using UnityEngine;

namespace Stacklands
{
    public class Food : MonoBehaviour
    {
        public void Consume()
        {
            Destroy(gameObject);
        }
    }
}