using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Palatro
{
    public class TileAnimation : MonoBehaviour
    {
        [SerializeField] float apparitionDuration = 0.5f;
            
        Vector2 initialPosition;

        void Start()
        {
            initialPosition = GetComponent<RectTransform>().anchoredPosition;
        }

        public Task Appear()
        {
            GetComponent<RectTransform>().anchoredPosition = initialPosition + Vector2.down * 200;
            return GetComponent<RectTransform>().DOAnchorPosY(initialPosition.y, apparitionDuration).AsyncWaitForCompletion();
        }    
    }
}