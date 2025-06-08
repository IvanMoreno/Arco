using UnityEngine;
using UnityEngine.UI;

namespace Palatro.UseCases
{
    public class ReRoll : MonoBehaviour
    {
        void Start()
        {
            GetComponent<Button>().onClick.AddListener(Execute);
        }

        async void Execute()
        {
            await FindAnyObjectByType<AttemptPanel>().Clear();
            await FindAnyObjectByType<Bank>().ReRoll();
        }
    }
}