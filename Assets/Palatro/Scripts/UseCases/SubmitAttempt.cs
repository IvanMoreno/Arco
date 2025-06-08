using System.Threading.Tasks;
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

        async void Execute()
        {
            var word = FindAnyObjectByType<AttemptPanel>().SpeltWord;
            
            if (!FindAnyObjectByType<ValidWords>().Whether(word))
                await ShowError();
            else
                await Submit(word);
        }

        static async Task Submit(Word word)
        {
            await FindAnyObjectByType<TextualPoints>().Show(word.Points);
            await FindAnyObjectByType<Score>().IncreaseBy(word.Points);
            await FindAnyObjectByType<AttemptPanel>().Clear();
            await FindAnyObjectByType<Bank>().PopulateProposedTiles();
            await FindAnyObjectByType<PlaysBar>().DownByOne();
        }

        static Task ShowError()
        {
            return FindAnyObjectByType<TextualPoints>().ShowError();
        }
    }
}