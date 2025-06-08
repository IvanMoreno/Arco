using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace Palatro
{
    public class TileWithPoints : MonoBehaviour
    {
        public string Letter { get; private set; }
        public int Points { get; private set; }

        public void Resemble(Letter letter) => 
            Resemble(letter.Shape, letter.Points);
        public void Resemble(string letter, int points)
        {
            Assert.IsNotNull(letter);
            Assert.IsTrue(points > 0);
        
            Letter = letter;
            Points = points;

            transform.Find("Character").GetComponent<TMP_Text>().text = Letter;
            transform.Find("Points").GetComponent<TMP_Text>().text = Points.ToString();
        }
    }
}
