using System.Linq;
using UnityEngine;

namespace Stacklands
{
    public class AlwaysOnTop : MonoBehaviour
    {
        public void OnMouseDown() => BringForward();

        public void BringForward()
        {
            var higherOrderInLayer = HighestOrderInLayer();
            foreach (var renderers in GetComponentsInChildren<SpriteRenderer>())
            {
                renderers.sortingOrder = ++higherOrderInLayer;
            }
        }

        static int HighestOrderInLayer()
        {
            var allSprites = FindObjectsByType<SpriteRenderer>(FindObjectsSortMode.None);
            return allSprites.Max(sprite => sprite.sortingOrder);
        }
    }
}