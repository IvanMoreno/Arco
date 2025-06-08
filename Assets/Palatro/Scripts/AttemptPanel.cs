using System.Linq;
using UnityEngine;
using static UnityEngine.FindObjectsSortMode;

namespace Palatro
{
    public class AttemptPanel : MonoBehaviour
    {
        public bool IsEmpty { get; }

        public void Place(LetterToPlay letter)
        {
            FindObjectsByType<LetterOfAttempt>(None).First(CanPlace).Place(letter);
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