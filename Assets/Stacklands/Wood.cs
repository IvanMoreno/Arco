using System;
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
        
        async void Start()
        {
            while (!destroyCancellationToken.IsCancellationRequested && numberOfHarvests > 0)
                await HarvestLoop();

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

            SpawnStick();
            harvestProgressInSeconds = 0;
            numberOfHarvests--;
        }

        void SpawnStick()
        {
            FindAnyObjectByType<SpaceTime>().SpawnNearbyCard(stickPrefab, transform.position);
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