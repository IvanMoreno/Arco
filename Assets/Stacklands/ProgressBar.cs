using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Stacklands
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] GameObject barParent;
        [SerializeField] Image progressBar;

        void Start()
        {
            Assert.IsNotNull(barParent);
            Assert.IsNotNull(progressBar);
        }

        public void ShowProgress(float howMuch)
        {
            Assert.IsTrue(howMuch <= 1 && howMuch >= 0, $"Porcentaje fuera de rango {howMuch}.");
            
            barParent.SetActive(true);
            progressBar.fillAmount = howMuch;
        }
        
        public void Hide()
        {
            barParent.SetActive(false);
            progressBar.fillAmount = 0;
        }
    }
}