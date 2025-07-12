using UnityEngine;

namespace Stacklands
{
    public class Stackable : MonoBehaviour
    {
        public void StackOver(Stackable other)
        {
            other.transform.position = transform.position + Vector3.down * 0.25f;
        }
    }
}