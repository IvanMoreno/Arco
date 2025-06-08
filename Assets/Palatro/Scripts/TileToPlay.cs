using UnityEngine;
using UnityEngine.UI;

namespace Palatro
{
    public class TileToPlay : MonoBehaviour
    {
        public Letter ActualLetter { get; private set; }
        
        void Awake()
        {
            var randomLetter = Alphabet.Random();
            ActualLetter = randomLetter;

            GetComponentInChildren<TileWithPoints>().Resemble(randomLetter);
            GetComponent<Button>().onClick.AddListener(PlaceInAttempt);
        }

        void PlaceInAttempt()
        {
            GetComponent<Button>().interactable = false;
            
            FindAnyObjectByType<AttemptPanel>().Place(this);
        }
    }
}