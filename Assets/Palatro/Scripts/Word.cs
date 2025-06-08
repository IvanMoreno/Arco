using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Palatro
{
    public readonly struct Word
    {
        readonly IEnumerable<Letter> letters;
        public string Shape => letters.Aggregate(string.Empty, (word, letter) => word + letter.Shape);
        public int Points
        {
            get
            {
                var result = 0;
                for (var i = 0; i < letters.Count(); i++)
                {
                    result += letters.ElementAt(i).Points + ExtraPointsFromPosition(i);
                }
                return result;
            }
        }

        Word(IEnumerable<Letter> letters) => this.letters = letters.ToList();

        public static Word From(IEnumerable<Letter> letters) => new(letters);
        
        // Esto pertenece aquí?
        public static int ExtraPointsFromPosition(int i)
        {
            Assert.IsTrue(i is >= 0 and < 10, $"Index {i} is out of range. It should be between 1 and 9.");
            return i switch
            {
                < 4 => 0,
                5 => 2,
                6 or 7 or 8 => 5,
                9 => 10,
                _ => 0
            };
        }
    }
}