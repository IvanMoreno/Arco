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

        void Execute() => FindAnyObjectByType<Bank>().ReRoll();
    }
}