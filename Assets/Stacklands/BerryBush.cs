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
                harvestProgressInSeconds = 0;
                return;
            }

            harvestProgressInSeconds += Time.deltaTime;
            if (harvestProgressInSeconds < harvestDurationInSeconds)
                return;

            SpawnBerry();
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