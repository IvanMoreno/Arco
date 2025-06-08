using System.Linq;
using UnityEngine;

namespace Palatro
{
    public class QA : MonoBehaviour
    {
        const string HardcodedValidWords = "HABITATION";
        
        [ContextMenu("Hardcode Reroll")]
        public void HardcodeReroll()
        {
            foreach (var tile in FindObjectsByType<TileToPlay>(FindObjectsSortMode.None))
            {
                tile.Resemble(new("X", 1));
            }
            
            for (var i = 0; i < HardcodedValidWords.Length; i++)
            {
                var letter = new Letter(HardcodedValidWords[i].ToString(), 1);
                FindObjectsByType<TileToPlay>(FindObjectsSortMode.None)
                    .OrderBy(tile => tile.transform.GetSiblingIndex())
                    .ElementAt(i)
                    .Resemble(letter);
            }
        }
    }
}