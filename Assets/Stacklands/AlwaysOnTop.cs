using System.Linq;
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
            // Cuidado, esto funciona de casualidad. Si se cambia el orden de jerarquía en prefab Card, falla.
            // Ejemplo: poner "Header" como primer hijo. 
            var allSprites = FindObjectsByType<SpriteRenderer>(FindObjectsSortMode.None);
            return allSprites.Max(sprite => sprite.sortingOrder);
        }
    }
}