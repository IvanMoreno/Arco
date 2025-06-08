using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Palatro
{
    public class LetterToPlay : MonoBehaviour
    {
        public string Letter => ActualLetter.Shape;
        public int Points => ActualLetter.Points;
        
        public Letter ActualLetter { get; private set; }
        
        void Awake()
        {
            var randomLetter = Alphabet.Random();
            ActualLetter = randomLetter;

            GetComponentInChildren<LetterWithPoints>().Resemble(randomLetter);
            GetComponent<Button>().onClick.AddListener(Play);
        }

        void Play()
        {
            GetComponent<Button>().interactable = false;
        }
    }
}