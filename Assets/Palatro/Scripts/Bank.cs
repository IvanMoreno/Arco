using System.Collections.Generic;
using System.Linq;
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

        public void ReRoll()
        {
            Populate(FindObjectsByType<TileToPlay>(None).ToList());
        }

        public void Reorder()
        {
            var allTiles = FindObjectsByType<TileToPlay>(None).ToList();
            foreach (var tile in allTiles)
                tile.transform.SetSiblingIndex(Random.Range(0, allTiles.Count));
        }

        void PopulateEmptyTiles()
        {
            Populate(FindObjectsByType<TileToPlay>(None).Where(x => x.IsEmpty).ToList());
        }
        
        public void PopulateProposedTiles()
        {
            Populate(FindObjectsByType<TileToPlay>(None).Where(x => x.IsProposed).ToList());
        }

        static void Populate(IReadOnlyList<TileToPlay> tiles)
        {
            var letters = FindAnyObjectByType<Bag>().Pick(tiles.Count);
            Assert.AreEqual(tiles.Count, letters.Count);

            for (var zip = 0; zip < tiles.Count; zip++)
                tiles[zip].Resemble(letters[zip]);
        }
    }
}