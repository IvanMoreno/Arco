using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Palatro.UseCases
{
    public class ScoreBar : MonoBehaviour
    {
        public Task FillUpTo(float proportion)
        {
            return GetComponent<Image>().DOFillAmount(proportion, 0.5f).AsyncWaitForCompletion();
        }
    }
}