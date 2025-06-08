using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Palatro.UseCases
{
    public class ScoreBar : MonoBehaviour
    {
        public Task FillUpTo(float percentage)
        {
            GetComponent<Image>().fillAmount = percentage;
            return Task.CompletedTask;
        }
    }
}