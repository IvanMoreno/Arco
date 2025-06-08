using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Palatro.UseCases
{
    public class ScoreBar : MonoBehaviour
    {
        public Task FillUpTo(float proportion)
        {
            GetComponent<Image>().fillAmount = proportion;
            return Task.CompletedTask;
        }
    }
}