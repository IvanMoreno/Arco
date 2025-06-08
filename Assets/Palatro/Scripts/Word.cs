using System.Collections.Generic;

namespace Palatro
{
    public readonly struct Word
    {
        readonly IEnumerable<Letter> letters;

        Word(IEnumerable<Letter> letters) => this.letters = letters;

        public static Word From(IEnumerable<Letter> letters) => new(letters);
    }
}