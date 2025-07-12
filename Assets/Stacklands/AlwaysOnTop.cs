using UnityEngine;

namespace Stacklands
{
    public class AlwaysOnTop : MonoBehaviour
    {
        public void OnMouseDown()
        {
            IncreaseSortingOrderStartingFrom(HigherOrderInLayer());
        }

        void IncreaseSortingOrderStartingFrom(int higherOrderInLayer)
        {
            foreach (var renderers in GetComponentsInChildren<SpriteRenderer>())
            {
                renderers.sortingOrder = ++higherOrderInLayer;
            }
        }

        static int HigherOrderInLayer()
        {
            var allSprites = FindObjectsByType<SpriteRenderer>(FindObjectsSortMode.None);
            var higherOrderInLayer = 0;

            // Cuidado, esto funciona de casualidad. Si se cambia el orden de jerarquía en prefab Card, falla.
            // Ejemplo: poner "Header" como primer hijo. 
            foreach (var sprite in allSprites)
            {
                if (sprite.sortingOrder <= higherOrderInLayer)
                    continue;

                higherOrderInLayer = sprite.sortingOrder;
            }

            return higherOrderInLayer;
        }
    }
}