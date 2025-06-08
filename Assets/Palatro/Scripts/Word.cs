using System.Collections.Generic;
using System.Linq;

namespace Palatro
{
    public readonly struct Word
    {
        readonly IEnumerable<Letter> letters;
        public string Shape => letters.Aggregate(string.Empty, (word, letter) => word + letter.Shape);

        Word(IEnumerable<Letter> letters) => this.letters = letters;

        public static Word From(IEnumerable<Letter> letters) => new(letters);
    }
}