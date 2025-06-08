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

            transform.Find("Letter").GetComponent<TMP_Text>().text = Letter;
            transform.Find("Points").GetComponent<TMP_Text>().text = Points.ToString();
            
            GetComponent<Button>().onClick.AddListener(Play);
        }

        void Play()
        {
            GetComponent<Button>().interactable = false;
        }
    }
}