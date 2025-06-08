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
            GetComponent<Button>().onClick.AddListener(Play);
        }

        void Play()
        {
            GetComponent<Button>().interactable = false;
        }
    }
}