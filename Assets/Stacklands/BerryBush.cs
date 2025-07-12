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

            GenerateBerry();
            harvestProgressInSeconds = 0;
            numberOfHarvests--;
        }

        void GenerateBerry()
        {
            Instantiate(berry, transform.position + Vector3.down, Quaternion.identity);
        }

        bool CanStartHarvest()
        {
            return GetComponent<Stackable>().HasSomethingStacked;
        }

        void DestroyItself()
        {
            GetComponentInChildren<Villager>().GetComponent<Stackable>().RemoveFromStack();
            Destroy(gameObject);
        }
    }
}