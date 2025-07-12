using UnityEngine;

namespace Stacklands
{
    public class Card : MonoBehaviour
    {
        public static readonly Vector2 AssumedSizeAprox = new(2, 2.25f);
        
        [SerializeField] string category;

        public bool IsStackableOnMe(Card other)
        {
            if (other.gameObject == gameObject)
                return false;
            if (GetComponent<Stackable>().HasSomethingStacked)
                return false;
            if (category == "structure")
                return other.category == "person";
            if (category == "person")
                return other.category == "structure";
            return true;
        }
    }
}