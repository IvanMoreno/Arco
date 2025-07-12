using UnityEngine;

namespace Stacklands
{
    public class Card : MonoBehaviour
    {
        [SerializeField] string category;

        public bool IsStackableOnMe(Card other)
        {
            if (category == "structure")
                return other.category == "person";
            if (category == "person")
                return other.category == "structure";
            return true;
        }
    }
}