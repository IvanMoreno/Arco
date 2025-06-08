using UnityEngine;
using UnityEngine.UI;

namespace Palatro.UseCases
{
    public class SubmitAttempt : MonoBehaviour
    {
        void Awake()
        {
            GetComponent<Button>().onClick.AddListener(Execute);
        }

        void Execute()
        {
            var word = FindAnyObjectByType<AttemptPanel>().SpeltWord;
            if (!FindAnyObjectByType<ValidWords>().Whether(word))
            {
                _ = FindAnyObjectByType<TextualPoints>().ShowError();
                return;
            }

            _ = FindAnyObjectByType<TextualPoints>().Show(word.Points);
            FindAnyObjectByType<AttemptPanel>().Clear();
            FindAnyObjectByType<Bank>().PopulateProposedTiles();
        }
    }
}