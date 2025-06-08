using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Palatro
{
    public class TileAnimation : MonoBehaviour
    {
        [SerializeField] float apparitionDuration = 0.5f;
            
        public Task Appear()
        {
            return GetComponent<RectTransform>().DOAnchorPosY(-200, apparitionDuration).From().AsyncWaitForCompletion();
        }    
    }
}