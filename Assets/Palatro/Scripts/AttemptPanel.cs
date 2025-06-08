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

        static IEnumerable<TileOfAttempt> AllLetterOfAttempts
            => FindObjectsByType<TileOfAttempt>(None)
                .OrderBy(tile => tile.transform.GetSiblingIndex());

        public void Place(TileToPlay tile)
        {
            Assert.IsTrue(AllLetterOfAttempts.Any(CanPlace));
            
            AllLetterOfAttempts.First(CanPlace).Place(tile);
        }

        static bool CanPlace(TileOfAttempt where) => where.IsEmpty;

        public void RemoveLastLetter()
        {
            Assert.IsTrue(AllLetterOfAttempts.Any(CannotPlace));

            AllLetterOfAttempts.Last(CannotPlace).Clear();
        }

        static bool CannotPlace(TileOfAttempt where) => !where.IsEmpty;

        public TileToPlay GetLastLetter()
        {
            Assert.IsTrue(AllLetterOfAttempts.Any(CannotPlace));
            
            return AllLetterOfAttempts.Last(CannotPlace).FilledWith;
        }
    }
}