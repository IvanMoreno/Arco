using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace Palatro
{
    public class LetterOfAttempt : MonoBehaviour
    {
        public int ExtraPoints { get; private set; }
        LetterToPlay filledWith;
        
        void Awake()
        {
            ToggleIsEmpty(true);
            ExtraPointsAre(ExtraPointsFromPosition(transform.GetSiblingIndex()));
        }

        public void Put(LetterToPlay letter)
        {
            Assert.IsNotNull(letter);
            Assert.IsNull(filledWith);
            
            filledWith = letter;
            ToggleIsEmpty(false);
        }

        void ExtraPointsAre(int howMany)
        {
            Assert.IsTrue(howMany >= 0);

            ExtraPoints = howMany;
            var extraPointsText = transform.Find("WhenIsEmpty/ExtraPoints");
        
            extraPointsText.GetComponentInChildren<TMP_Text>().text = howMany > 0 ? "+" + howMany : "";
        }

        void ToggleIsEmpty(bool isEmpty)
        {
            transform.Find("WhenIsEmpty").gameObject.SetActive(isEmpty);
            transform.Find("WhenIsFilledWithLetter").gameObject.SetActive(!isEmpty);

            if (!isEmpty)
            {
                transform.Find("WhenIsFilledWithLetter/Character").GetComponent<TMP_Text>().text = filledWith.Letter;
                transform.Find("WhenIsFilledWithLetter/Points").GetComponent<TMP_Text>().text = filledWith.Points.ToString();
            }
        }

        static int ExtraPointsFromPosition(int i)
        {
            Assert.IsTrue(i is >= 0 and < 10, $"Index {i} is out of range. It should be between 1 and 9.");
            return i switch
            {
                < 4 => 0,
                5 => 2,
                6 or 7 or 8 => 5,
                9 => 10,
                _ => 0
            };
        }
    }
}
