using UnityEngine;
using UnityEngine.UI;

namespace Palatro.UseCases
{
    public class Reorder : MonoBehaviour
    {
        void Awake()
        {
            GetComponent<Button>().onClick.AddListener(ReorderBank);
        }

        async void ReorderBank() => await FindAnyObjectByType<Bank>().Reorder();
    }
}