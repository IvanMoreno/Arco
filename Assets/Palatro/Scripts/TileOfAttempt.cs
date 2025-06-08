using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace Palatro
{
    public class TileOfAttempt : MonoBehaviour
    {
        public int ExtraPoints { get; private set; }
        public bool IsEmpty { get; private set; }
        
        public TileToPlay FilledWith { get; private set; }
        
        void Start()
        {
            ToggleIsEmpty(true);
            ExtraPointsAre(Word.ExtraPointsFromPosition(transform.GetSiblingIndex()));
        }

        public Task Place(TileToPlay tile)
        {
            Assert.IsNotNull(tile);
            Assert.IsNull(FilledWith);
            
            FilledWith = tile;
            return ToggleIsEmpty(false);
        }

        void ExtraPointsAre(int howMany)
        {
            Assert.IsTrue(howMany >= 0);

            ExtraPoints = howMany;
            var extraPointsText = transform.Find("WhenIsEmpty/ExtraPoints");
        
            extraPointsText.GetComponentInChildren<TMP_Text>().text = howMany > 0 ? "+" + howMany : "";
        }

        public Task Clear()
        {
            Assert.IsNotNull(FilledWith);
            
            FilledWith = null;
            return ToggleIsEmpty(true);
        }

        async Task ToggleIsEmpty(bool isEmpty)
        {
            IsEmpty = isEmpty;
            
            if (isEmpty)
            {
                await GetComponentInChildren<TileAnimation>().Disappear();
                transform.Find("WhenIsFilledWithLetter").gameObject.SetActive(false);
                return;
            }
            
            transform.Find("WhenIsFilledWithLetter").gameObject.SetActive(true);
            GetComponentInChildren<TileWithPoints>().Resemble(FilledWith.ActualLetter);
            await GetComponentInChildren<TileAnimation>().Appear();
        }
    }
}
