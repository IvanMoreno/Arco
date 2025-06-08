using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Palatro
{
    public class TileToPlay : MonoBehaviour
    {
        public Letter ActualLetter { get; private set; }
        
        public bool IsEmpty => ActualLetter == null;
        public bool IsProposed => !GetComponent<Button>().interactable;

        void Awake()
        {
            GetComponent<Button>().onClick.AddListener(PlaceInAttempt);
        }

        public void Resemble(Letter randomLetter)
        {
            ActualLetter = randomLetter;

            GetComponentInChildren<TileWithPoints>().Resemble(randomLetter);
            
            GetComponent<Button>().interactable = true;
        }

        void PlaceInAttempt()
        {
            Assert.IsFalse(IsEmpty);
            
            var attemptPanel = FindAnyObjectByType<AttemptPanel>();
            if (!attemptPanel.ThereIsSpace())
                return;

            attemptPanel.Place(this);
            GetComponent<Button>().interactable = false;
        }

        public Task RemoveFromAttempt()
        {
            GetComponent<Button>().interactable = true;
            return Task.CompletedTask;
        }
    }
}