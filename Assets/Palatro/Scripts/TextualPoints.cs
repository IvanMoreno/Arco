using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Palatro
{
    public class TextualPoints : MonoBehaviour
    {
        public async Task Show(int howMuch)
        {
            GetComponent<TMP_Text>().text = $"Points: {howMuch}";
            await Task.Delay(1000);
            GetComponent<TMP_Text>().text = string.Empty;
        }

        public async Task ShowError()
        {
            GetComponent<TMP_Text>().text = "NOT VALID";
            await Task.Delay(1000);
            GetComponent<TMP_Text>().text = string.Empty;
        }
    }
}