using UnityEngine;
using UnityEngine.UI;

namespace Palatro
{
    public class LetterToPlay : MonoBehaviour
    {
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