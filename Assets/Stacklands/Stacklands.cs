using System;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace Stacklands
{
    public class Stacklands : MonoBehaviour
    {
        [SerializeField] Stackable assumedAsSelected;

        void Update()
        {
            if (!Input.GetKeyDown(KeyCode.A))
                return;

            var randomStackable = FindObjectsOfType<Stackable>().First(x => x != assumedAsSelected);
            assumedAsSelected.StackOnMe(randomStackable);
            assumedAsSelected = randomStackable;
        }
    }
}