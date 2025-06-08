using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace Palatro
{
    public class Bag : MonoBehaviour
    {
        const int AmountToBeginWith = 100;

        ICollection<Letter> lettersInside;

        void Awake()
        {
            lettersInside = Enumerable.Range(0, AmountToBeginWith).Select(_ => Alphabet.Random()).ToList();
        }

        public IReadOnlyList<Letter> Pick(int howMany)
        {
            Assert.IsTrue(howMany > 0);
            var letters = new List<Letter>();
            
            Assert.IsTrue(lettersInside.Count >= howMany, "todavía no manejamos que te quedes sin letras en la bag");
            
            for (var i = 0; i < howMany; i++)
            {
                var nextLetter = lettersInside.First();
                letters.Add(nextLetter);
                lettersInside.Remove(nextLetter);
            }
            
            return letters;
        }
    }
}