using System;
using UnityEngine;
using UnityEngine.UI;

namespace Stacklands
{
    public class Moon : MonoBehaviour
    {
        void Start()
        {
            GetComponent<Image>().fillAmount = 0;
        }

        void Update()
        {
            GetComponent<Image>().fillAmount += Time.deltaTime / 60f;
            
        }
    }
}