using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace Palatro
{
    public class TileWithPoints : MonoBehaviour
    {
        public string Letter { get; private set; }
        public int Points { get; private set; }

        public void Resemble(Letter letter)
        {
            Assert.IsNotNull(letter.Shape);
            Assert.IsTrue(letter.Points > 0);
        
            Letter = letter.Shape;
            Points = letter.Points;

            transform.Find("Character").GetComponent<TMP_Text>().text = Letter;
            transform.Find("Points").GetComponent<TMP_Text>().text = Points.ToString();
        }
    }
}
