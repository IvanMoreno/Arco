using UnityEngine;

namespace Stacklands
{
    public class Villager : MonoBehaviour
    {
        public void Die()
        {
            GetComponentInChildren<SpriteRenderer>().color = Color.gray;
        }
    }
}