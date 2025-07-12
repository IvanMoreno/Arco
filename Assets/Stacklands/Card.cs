using UnityEngine;

namespace Stacklands
{
    public class Card : MonoBehaviour
    {
        [SerializeField] string category;

        public bool IsStackableOnMe(Card other)
        {
            if (category == "person")
                return false;
            return true;
        }
    }
}