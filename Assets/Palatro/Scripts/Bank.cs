using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace Palatro
{
    public class Bank : MonoBehaviour
    {
        void Awake()
        {
            PopulateEmptyTiles();
        }

        public void PopulateEmptyTiles()
        {
            var emptyTiles = FindObjectsByType<TileToPlay>(FindObjectsSortMode.None).Where(x => x.IsEmpty).ToList();
            var letters = FindAnyObjectByType<Bag>().Pick(emptyTiles.Count);
            Assert.AreEqual(emptyTiles.Count, letters.Count);
            
            for (var zip = 0; zip < emptyTiles.Count; zip++)
                emptyTiles[zip].Resemble(letters[zip]);
        }
    }
}