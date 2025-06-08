using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Palatro
{
    public class Bag : MonoBehaviour
    {
        const int AmountToBeginWith = 100;

        IReadOnlyCollection<Letter> lettersInside
            => Enumerable.Range(0, AmountToBeginWith).Select(_ => Alphabet.Random()).ToList();

        public IReadOnlyList<Letter> Pick(int count)
        {
            var letters = new List<Letter>();
            for (var i = 0; i < count; i++)
                letters.Add(Alphabet.Random());
            return letters;
        }
    }
}