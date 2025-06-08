using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace Palatro
{
    public class TileOfAttempt : MonoBehaviour
    {
        public int ExtraPoints { get; private set; }
        public bool IsEmpty => transform.Find("WhenIsEmpty").gameObject.activeInHierarchy;
        
        public TileToPlay FilledWith { get; private set; }
        
        void Awake()
        {
            ToggleIsEmpty(true);
            ExtraPointsAre(Word.ExtraPointsFromPosition(transform.GetSiblingIndex()));
        }

        public void Place(TileToPlay tile)
        {
            Assert.IsNotNull(tile);
            Assert.IsNull(FilledWith);
            
            FilledWith = tile;
            ToggleIsEmpty(false);
        }

        void ExtraPointsAre(int howMany)
        {
            Assert.IsTrue(howMany >= 0);

            ExtraPoints = howMany;
            var extraPointsText = transform.Find("WhenIsEmpty/ExtraPoints");
        
            extraPointsText.GetComponentInChildren<TMP_Text>().text = howMany > 0 ? "+" + howMany : "";
        }

        public void Clear()
        {
            Assert.IsNotNull(FilledWith);
            
            FilledWith = null;
            ToggleIsEmpty(true);
        }

        void ToggleIsEmpty(bool isEmpty)
        {
            transform.Find("WhenIsEmpty").gameObject.SetActive(isEmpty);
            transform.Find("WhenIsFilledWithLetter").gameObject.SetActive(!isEmpty);

            if (!isEmpty)
                GetComponentInChildren<TileWithPoints>().Resemble(FilledWith.ActualLetter);
        }
    }
}
