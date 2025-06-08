using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Palatro.UseCases
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

        static void RemoveLastLetter()
        {
            _ = FindAnyObjectByType<AttemptPanel>().GetLastLetter().RemoveFromAttempt();
        }
    }
}