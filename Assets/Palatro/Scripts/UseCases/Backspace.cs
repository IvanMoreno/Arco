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
            Task.WhenAll(new List<Task>
            {
                FindAnyObjectByType<AttemptPanel>().GetLastLetter().RemoveFromAttempt(),
                FindAnyObjectByType<AttemptPanel>().RemoveLastLetter()
            });
        }
    }
}