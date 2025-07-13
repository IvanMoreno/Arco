using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Stacklands
{
    public class BerryBush : MonoBehaviour
    {
        const float harvestDurationInSeconds = 2;
        
        [SerializeField] GameObject berry;

        float harvestProgressInSeconds;
        int numberOfHarvests = 2;
        
        async void Start()
        {
            while (!destroyCancellationToken.IsCancellationRequested && numberOfHarvests > 0)
            {
                await HarvestLoop();
            }

            DestroyItself();
        }

        async Task HarvestLoop()
        {
            await Task.Yield();
            if (!CanStartHarvest())
            {
                GetComponentInChildren<ProgressBar>().Hide();
                harvestProgressInSeconds = 0;
                return;
            }

            harvestProgressInSeconds = Mathf.Clamp(harvestProgressInSeconds + Time.deltaTime, 0, harvestDurationInSeconds);
            GetComponentInChildren<ProgressBar>().ShowProgress(harvestProgressInSeconds / harvestDurationInSeconds);
            if (harvestProgressInSeconds < harvestDurationInSeconds)
                return;

            SpawnBerry();
            GetComponentInChildren<ProgressBar>().Hide();
            harvestProgressInSeconds = 0;
            numberOfHarvests--;
        }

        void SpawnBerry()
        {
            FindAnyObjectByType<SpaceTime>().SpawnNearbyCard(berry, transform.position);
        }

        bool CanStartHarvest()
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