using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Palatro
{
    public class LetterToPlay : MonoBehaviour
    {
        public string Letter { get; private set; }
        public int Points { get; private set; }
        
        void Awake()
        {
            var randomLetter = Alphabet.Random();
            Letter = randomLetter.Shape;
            Points = randomLetter.Points;

            GetComponentInChildren<LetterWithPoints>().Resemble(randomLetter);
            GetComponent<Button>().onClick.AddListener(Play);
        }

        void Play()
        {
            GetComponent<Button>().interactable = false;
        }
    }
}