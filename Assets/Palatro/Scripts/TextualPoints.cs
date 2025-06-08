using System;
using System.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Palatro
{
    public class TextualPoints : MonoBehaviour
    {
        void Awake()
        {
            GetComponent<CanvasGroup>().alpha = 0;
        }

        public async Task Show(int howMuch)
        {
            GetComponent<CanvasGroup>().alpha = 0;
            GetComponentInChildren<TMP_Text>().text = $"Points: {howMuch}";
            await GetComponent<CanvasGroup>().DOFade(1, 0.25f)
                .SetEase(Ease.OutCubic)
                .AsyncWaitForCompletion();
            await Task.Delay(1000);

            await GetComponent<CanvasGroup>().DOFade(0, 0.25f)
                .SetEase(Ease.InCubic)
                .AsyncWaitForCompletion();
            GetComponentInChildren<TMP_Text>().text = string.Empty;
        }

        public async Task ShowError()
        {
            GetComponentInChildren<CanvasGroup>().alpha = 1;
            GetComponentInChildren<TMP_Text>().text = "NOT VALID";
            await Task.Delay(1000);
            GetComponentInChildren<TMP_Text>().text = string.Empty;
        }
    }
}