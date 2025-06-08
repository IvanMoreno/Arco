using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using static UnityEngine.FindObjectsSortMode;

namespace Palatro
{
    public class AttemptPanel : MonoBehaviour
    {
        public bool IsEmpty => AllLetterOfAttempts.All(CanPlace);
        public Word SpeltWord => Word.From(PlacedTiles.Select(x => x.FilledWith.ActualLetter));
        static IEnumerable<TileOfAttempt> PlacedTiles => AllLetterOfAttempts.Where(IsOccupied);

        static IEnumerable<TileOfAttempt> AllLetterOfAttempts
            => FindObjectsByType<TileOfAttempt>(None)
                .OrderBy(tile => tile.transform.GetSiblingIndex());

        public void Place(TileToPlay tile)
        {
            Assert.IsTrue(ThereIsSpace());
            AllLetterOfAttempts.First(CanPlace).Place(tile);
        }

        public bool ThereIsSpace()
        {
            return AllLetterOfAttempts.Any(CanPlace);
        }

        static bool CanPlace(TileOfAttempt where) => where.IsEmpty;

        public void RemoveLastLetter()
        {
            Assert.IsFalse(IsEmpty);

            AllLetterOfAttempts.Last(IsOccupied).Clear();
        }

        static bool IsOccupied(TileOfAttempt where) => !where.IsEmpty;

        public TileToPlay GetLastLetter()
        {
            Assert.IsFalse(IsEmpty);
            
            return AllLetterOfAttempts.Last(IsOccupied).FilledWith;
        }
    }
}