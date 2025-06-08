using System;

namespace Palatro
{
    public class Alphabet
    {
        public static Letter Random()
        {
            var randomLetter = (char)('A' + new Random().Next(0, 26));
            var randomPoints = new Random().Next(1, 5);

            return new(randomLetter.ToString(), randomPoints);
        }
    }
}