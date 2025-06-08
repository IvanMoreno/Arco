using System;
using UnityEngine;
using UnityEngine.UI;

namespace Palatro
{
    public class Reorder : MonoBehaviour
    {
        void Awake()
        {
            GetComponent<Button>().onClick.AddListener(ReorderBank);
        }

        void ReorderBank() => FindAnyObjectByType<Bank>().Reorder();
    }
}