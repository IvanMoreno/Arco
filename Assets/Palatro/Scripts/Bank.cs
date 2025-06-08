using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;
using static UnityEngine.FindObjectsSortMode;

namespace Palatro
{
    public class Bank : MonoBehaviour
    {
        void Start()
        {
            PopulateEmptyTiles();
        }

        public Task ReRoll()
        {
            return Populate(FindObjectsByType<TileToPlay>(None).ToList());
        }

        public Task Reorder()
        {
            var allTiles = FindObjectsByType<TileToPlay>(None).ToList();
            foreach (var tile in allTiles)
                tile.transform.SetSiblingIndex(Random.Range(0, allTiles.Count));

            return Task.CompletedTask;
        }

        void PopulateEmptyTiles()
        {
            _ = Populate(FindObjectsByType<TileToPlay>(None).Where(x => x.IsEmpty).ToList());
        }
        
        public Task PopulateProposedTiles()
        {
            return Populate(FindObjectsByType<TileToPlay>(None).Where(x => x.IsProposed).ToList());
        }

        static async Task Populate(IReadOnlyList<TileToPlay> tiles)
        {
            var letters = FindAnyObjectByType<Bag>().Pick(tiles.Count);
            Assert.AreEqual(tiles.Count, letters.Count);

            var tilesResemble = tiles.Select((tile, i) => tile.Resemble(letters[i])).ToList();
            foreach (var resembleTask in tilesResemble)
                await resembleTask;
        }
    }
}