using UnityEngine;
using UnityEngine.UI;

namespace Palatro
{
    public class Backspace : MonoBehaviour
    {
        void Start()
        {
            GetComponent<Button>().onClick.AddListener(RemoveLastLetter);
        }

        void Update()
        {
            GetComponent<Button>().interactable = !FindAnyObjectByType<AttemptPanel>().IsEmpty;
        }

        void RemoveLastLetter()
        {
            FindAnyObjectByType<AttemptPanel>().GetLastLetter().RemoveFromAttempt();
            FindAnyObjectByType<AttemptPanel>().RemoveLastLetter();
        }
    }
}