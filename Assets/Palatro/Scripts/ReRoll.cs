using UnityEngine;
using UnityEngine.UI;

namespace Palatro
{
    public class ReRoll : MonoBehaviour
    {
        void Start()
        {
            GetComponent<Button>().onClick.AddListener(Execute);
        }

        async void Execute() => await FindAnyObjectByType<Bank>().ReRoll();
    }
}