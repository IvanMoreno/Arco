using System;
using System.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Palatro
{
    public class PlaysBar : MonoBehaviour
    {
        int attemptsLeft;
        int maxAttempts;
        
        float ProportionOfAttemptsLeft => (float)attemptsLeft / maxAttempts;

        void Awake()
        {
            transform.Find("Badge").gameObject.SetActive(false);
        }

        void Start()
        {
            BeginWith(11);
        }

        public void BeginWith(int amountOfAttempts)
        {
            Assert.IsTrue(amountOfAttempts > 0);
            
            maxAttempts = amountOfAttempts;
            attemptsLeft = amountOfAttempts;
        }
        public Task DownByOne()
        {
            Assert.IsTrue(attemptsLeft > 0);
            
            attemptsLeft--;
            return UpdateBar();
        }

        async Task UpdateBar()
        {
            await FirstShowBadge();
            
            var text = transform.Find("RemainingPlays").GetComponent<TMP_Text>();
            text.text = attemptsLeft.ToString();
            
            await transform.Find("Fill").GetComponent<Image>().DOFillAmount(ProportionOfAttemptsLeft, 0.5f)
                .SetEase(Ease.OutCubic)
                .AsyncWaitForCompletion();

            await FadeOutBadge();
        }

        async Task FadeOutBadge()
        {
            var badge = transform.Find("BadgeClone");
            await badge.GetComponent<CanvasGroup>().DOFade(0, 0.5f)
                .SetEase(Ease.InCubic)
                .AsyncWaitForCompletion();
            Destroy(badge.gameObject);
        }

        Task FirstShowBadge()
        {
            var originalBadge = transform.Find("Badge");
            var clone = Instantiate(originalBadge, originalBadge.position, originalBadge.rotation, transform);
            clone.name = "BadgeClone";
            clone.gameObject.SetActive(true);
            
            return clone.DOLocalMoveY(-100, 0.5f).From().SetEase(Ease.OutBack).AsyncWaitForCompletion();
        }
    }
}