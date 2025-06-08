using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Palatro
{
    public class TileToPlay : MonoBehaviour
    {
        public Letter ActualLetter { get; private set; }
        
        public bool IsEmpty => ActualLetter == null;
        public bool IsProposed => !GetComponentInChildren<Button>().interactable;

        void Awake()
        {
            GetComponentInChildren<Button>().onClick.AddListener(PlaceInAttempt);
        }

        public Task Resemble(Letter randomLetter)
        {
            ActualLetter = randomLetter;

            GetComponentInChildren<TileWithPoints>().Resemble(randomLetter);
            return Appear();
        }

        void PlaceInAttempt()
        {
            Assert.IsFalse(IsEmpty);
            
            var attemptPanel = FindAnyObjectByType<AttemptPanel>();
            if (!attemptPanel.ThereIsSpace()) return;

            Task.WhenAll(Disappear(), attemptPanel.Place(this));
        }

        public Task RemoveFromAttempt()
        {
            FindAnyObjectByType<AttemptPanel>().Remove(this);
            return Appear();
        }

        Task Appear()
        {
            GetComponentInChildren<Button>().interactable = true;
            
            var allImagesOfTheButton = GetComponentInChildren<Button>().GetComponentsInChildren<Image>();
            foreach (var image in allImagesOfTheButton)
                image.CrossFadeAlpha(1, 0.25f, true);
            GetComponentInChildren<Button>().transform.Find("Points").GetComponent<TMP_Text>().alpha = 1;
            return Task.Delay(TimeSpan.FromSeconds(.25f));
        }

        Task Disappear()
        {
            GetComponentInChildren<Button>().interactable = false;
            
            var allImagesOfTheButton = GetComponentInChildren<Button>().GetComponentsInChildren<Image>();
            foreach (var image in allImagesOfTheButton)
                image.CrossFadeAlpha(0, 0.25f, true);
            GetComponentInChildren<Button>().transform.Find("Points").GetComponent<TMP_Text>().alpha = 0;
            return Task.Delay(TimeSpan.FromSeconds(.25f));
        }
    }
}