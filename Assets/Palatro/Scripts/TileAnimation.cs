using System;
using System.Threading.Tasks;
using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace Palatro
{
    public class TileAnimation : MonoBehaviour
    {
        [SerializeField] float apparitionDuration = 0.5f;
        [SerializeField] float dissipationDuration = 0.5f;

        Vector2 initialPosition;

        void Start()
        {
            initialPosition = GetComponent<RectTransform>().anchoredPosition;
        }

        public Task Appear()
        {
            GetComponent<RectTransform>().anchoredPosition = initialPosition;
            return GetComponent<RectTransform>().DOAnchorPosY(-200, apparitionDuration).From().AsyncWaitForCompletion();
        }
        
        public Task Disappear()
        {
            GetComponent<RectTransform>().anchoredPosition = initialPosition;
            return GetComponent<RectTransform>().DOAnchorPosY(200, dissipationDuration).AsyncWaitForCompletion();
        }
    }
}