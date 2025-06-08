using System.Collections.Generic;
using UnityEngine;

namespace Palatro
{
    public class Bag : MonoBehaviour
    {
        public IEnumerable<Letter> Pick(int count)
        {
            var letters = new List<Letter>();
            for (var i = 0; i < count; i++)
                letters.Add(Alphabet.Random());
            return letters;
        }
    }
}