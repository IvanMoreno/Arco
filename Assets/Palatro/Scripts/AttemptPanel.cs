using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using static UnityEngine.FindObjectsSortMode;

namespace Palatro
{
    public class AttemptPanel : MonoBehaviour
    {
        public bool IsEmpty { get; }

        static IEnumerable<LetterOfAttempt> AllLetterOfAttempts => FindObjectsByType<LetterOfAttempt>(None);

        public void Place(LetterToPlay letter)
        {
            Assert.IsTrue(AllLetterOfAttempts.Any(CanPlace));
            
            AllLetterOfAttempts.First(CanPlace).Place(letter);
        }

        static bool CanPlace(LetterOfAttempt where) => where.IsEmpty;

        public void RemoveLastLetter()
        {
            
        }

        public LetterToPlay GetLastLetter()
        {
            return null;
        }
    }
}