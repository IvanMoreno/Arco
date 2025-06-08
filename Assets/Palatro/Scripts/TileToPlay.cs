using System.Collections.Generic;
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
        public bool IsProposed => !GetComponentInChildren<Button>().interactable;

        void Awake()
        {
            GetComponentInChildren<Button>().onClick.AddListener(PlaceInAttempt);
        }

        public Task Resemble(Letter randomLetter)
        {
            ActualLetter = randomLetter;

            GetComponentInChildren<TileWithPoints>().Resemble(randomLetter);
            
            GetComponentInChildren<Button>().interactable = true;
            return Task.CompletedTask;
        }

        void PlaceInAttempt()
        {
            Assert.IsFalse(IsEmpty);
            
            var attemptPanel = FindAnyObjectByType<AttemptPanel>();
            if (!attemptPanel.ThereIsSpace()) return;

            Task.WhenAll(new List<Task>
            {
                Disappear(),
                attemptPanel.Place(this)
            });
        }

        Task Disappear()
        {
            GetComponentInChildren<Button>().interactable = false;
            return Task.CompletedTask;
        }

        public Task RemoveFromAttempt()
        {
            FindAnyObjectByType<AttemptPanel>().Remove(this);
            GetComponentInChildren<Button>().interactable = true;
            return Task.CompletedTask;
        }
    }
}