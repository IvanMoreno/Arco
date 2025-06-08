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

        Task UpdateBar()
        {
            var text = transform.Find("RemainingPlays").GetComponent<TMP_Text>();
            text.text = attemptsLeft.ToString();
            
            return transform.Find("Fill").GetComponent<Image>().DOFillAmount(ProportionOfAttemptsLeft, 0.5f)
                .SetEase(Ease.OutCubic)
                .AsyncWaitForCompletion();
        }
    }
}