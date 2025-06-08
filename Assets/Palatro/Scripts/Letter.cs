using UnityEngine;
using UnityEngine.UI;

namespace Palatro
{
    public class Letter : MonoBehaviour
    {
        void Awake()
        {
            GetComponent<Button>().onClick.AddListener(Place);
        }

        void Place()
        {
            GetComponent<Button>().interactable = false;
        }
    }
}