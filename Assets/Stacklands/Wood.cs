using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Stacklands
{
    public class Wood : MonoBehaviour
    {
        const float harvestDurationInSeconds = 2.75f;
        
        [SerializeField] GameObject stickPrefab;
        
        float harvestProgressInSeconds;
        int numberOfHarvests = 1;
        
        async Task Start()
        {
            while (!destroyCancellationToken.IsCancellationRequested && numberOfHarvests > 0)
            {
                HarvestLoop();
                await Task.Yield();
            }

            DestroyItself();
        }

        void HarvestLoop()
        {
            UpdateProgress();
            if (harvestProgressInSeconds < harvestDurationInSeconds)
                return;

            SpawnBerry();
            ResetProgress();
            numberOfHarvests--;
        }

        void UpdateProgress()
        {
            if (!IsHarvestInProgress())
            {
                ResetProgress();
                return;
            }
            
            harvestProgressInSeconds = Mathf.Clamp(harvestProgressInSeconds + Time.deltaTime, 0, harvestDurationInSeconds);
            GetComponentInChildren<ProgressBar>().ShowProgress(harvestProgressInSeconds / harvestDurationInSeconds);
        }

        void ResetProgress()
        {
            GetComponentInChildren<ProgressBar>().Hide();
            harvestProgressInSeconds = 0;
        }

        void SpawnBerry()
        {
            FindAnyObjectByType<SpaceTime>().SpawnNearbyCard(stickPrefab, transform.position);
        }

        bool IsHarvestInProgress()
        {
            return GetComponent<Stackable>().TheWholeStackOverMe.FirstOrDefault()?.TryGetComponent<Villager>(out _) ?? false;
        }

        void DestroyItself()
        {
            GetComponentInChildren<Villager>().GetComponent<Stackable>().RemoveFromStack();
            Destroy(gameObject);
        }
    }
}