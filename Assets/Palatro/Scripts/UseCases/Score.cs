using System.Threading.Tasks;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Palatro.UseCases
{
    public class Score : MonoBehaviour
    {
        const int InitialPoints = 75;
        const int TargetPointsIncrementPerRound = 15;
        const int MaxRounds = 12;

        [SerializeField] TMP_Text pointsLabel;
        [SerializeField] TMP_Text roundLabel;
            
        int currentPoints;
        int targetPoints;
        int currentRound;

        void Start()
        {
            targetPoints = InitialPoints;
            currentRound = 1;

            UpdateLabels();
        }

        public async Task IncreaseBy(int points)
        {
            Assert.IsTrue(points > 0);
            
            currentPoints += points;
            pointsLabel.text = $"{currentPoints} / {targetPoints}";
            await GetComponentInChildren<ScoreBar>().FillUpTo((float)currentPoints / targetPoints);

            if (currentPoints >= targetPoints)
            {
                currentPoints = 0;
                currentRound++;
                targetPoints += TargetPointsIncrementPerRound;
                
                UpdateLabels();
            }
        }

        void UpdateLabels()
        {
            roundLabel.text = $"ROUND {currentRound} / {MaxRounds}";
            pointsLabel.text = $"{currentPoints} / {targetPoints}";
        }
    }
}