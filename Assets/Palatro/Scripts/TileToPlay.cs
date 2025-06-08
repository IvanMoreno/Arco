using UnityEngine;
using UnityEngine.UI;

namespace Palatro
{
    public class TileToPlay : MonoBehaviour
    {
        public Letter ActualLetter { get; private set; }
        
        public bool IsEmpty => ActualLetter == null;

        public void Resemble(Letter randomLetter)
        {
            ActualLetter = randomLetter;

            GetComponentInChildren<TileWithPoints>().Resemble(randomLetter);
            GetComponent<Button>().onClick.AddListener(PlaceInAttempt);
        }

        void PlaceInAttempt()
        {
            var attemptPanel = FindAnyObjectByType<AttemptPanel>();
            if (!attemptPanel.ThereIsSpace())
                return;

            attemptPanel.Place(this);
            GetComponent<Button>().interactable = false;
        }

        public void RemoveFromAttempt()
        {
            GetComponent<Button>().interactable = true;
        }
    }
}