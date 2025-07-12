using System;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Stacklands
{
    public class Moon : MonoBehaviour
    {
        void Awake()
        {
            GetComponent<Image>().fillAmount = 0;
        }
        
        async void Start()
        {
            await UntilFullMoon();
            
            var button = FindObjectsOfType<Button>(true).Single(x => x.name == "NextCycle");
            button.gameObject.SetActive(true);
            button.onClick.AddListener(() =>
            {
                GetComponent<Image>().fillAmount = 0;
                button.gameObject.SetActive(false);
            });
        }

        async Task UntilFullMoon()
        {
            while (GetComponent<Image>().fillAmount < 1f)
                await Task.Yield();
        }

        void Update()
        {
            var cycleSeconds = 60f;
            if (Input.GetKey(KeyCode.Space))
                cycleSeconds /= 50;
            GetComponent<Image>().fillAmount += Time.deltaTime / cycleSeconds;
        }
    }
}