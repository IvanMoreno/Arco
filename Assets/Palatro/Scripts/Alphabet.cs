using System;
using System.Collections.Generic;
using System.Linq;

namespace Palatro
{
    public class Alphabet
    {
        public static Letter Random()
        {
            return RandomByFreq();
        }

        static Letter RandomByFreq()
        {
            var distribution = new Dictionary<char, double>()
            {
                { 'A', 8.17 }, { 'B', 1.49 }, { 'C', 2.78 }, { 'D', 4.25 }, { 'E', 12.70 },{ 'F', 2.23 }, { 'G', 2.02 },
                { 'H', 6.09 }, { 'I', 7.00 }, { 'J', 0.15 }, { 'K', 0.77 }, { 'L', 4.03 }, { 'M', 2.41 }, { 'N', 6.75 },
                { 'O', 7.51 }, { 'P', 1.93 }, { 'Q', 0.10 }, { 'R', 5.99 }, { 'S', 6.33 }, { 'T', 9.06 }, { 'U', 2.76 },
                { 'V', 0.98 }, { 'W', 2.36 }, { 'X', 0.15 }, { 'Y', 1.97 }, { 'Z', 0.07 }
            };
            var points = new Dictionary<char, int>()
            {
                { 'A', 1 }, { 'B', 3 }, { 'C', 3 }, { 'D', 2 }, { 'E', 1 }, { 'F', 4 }, { 'G', 2 },
                { 'H', 4 }, { 'I', 1 }, { 'J', 8 }, { 'K', 5 }, { 'L', 1 }, { 'M', 3 }, { 'N', 1 },
                { 'O', 1 }, { 'P', 3 }, { 'Q', 10 }, { 'R', 1 }, { 'S', 1 }, { 'T', 1 }, { 'U', 1 },
                { 'V', 4 }, { 'W', 4 }, { 'X', 8 }, { 'Y', 4 }, { 'Z', 10 }
            };
            var totalWeight = distribution.Values.Sum();
            
            var randomValue = new Random().NextDouble() * totalWeight;
            foreach (var kvp in distribution)
            {
                if (randomValue < kvp.Value) 
                    return new(kvp.Key.ToString(), points[kvp.Key]);
                randomValue -= kvp.Value;
            }
            throw new InvalidOperationException("Failed to select a letter based on frequency distribution.");
        }
    }
}