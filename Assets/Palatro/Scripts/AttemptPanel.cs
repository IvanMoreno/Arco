using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;
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

        public Task Place(TileToPlay tile)
        {
            Assert.IsTrue(ThereIsSpace());
            return AllLetterOfAttempts.First(CanPlace).Place(tile);
        }

        public bool ThereIsSpace()
        {
            return AllLetterOfAttempts.Any(CanPlace);
        }

        static bool CanPlace(TileOfAttempt where) => where.IsEmpty;

        public Task Remove(TileToPlay placedTile)
        {
            Assert.IsTrue(PlacedTiles.Any(tile => tile.FilledWith.Equals(placedTile)));

            return PlacedTiles.Single(tile => tile.FilledWith.Equals(placedTile)).Clear();
        }

        static bool IsOccupied(TileOfAttempt where) => !where.IsEmpty;

        public TileToPlay GetLastLetter()
        {
            Assert.IsFalse(IsEmpty);
            
            return AllLetterOfAttempts.Last(IsOccupied).FilledWith;
        }

        public async Task Clear()
        {
            foreach (var tileOfAttempt in PlacedTiles)
            {
                await tileOfAttempt.Clear();
            }
        }
    }
}