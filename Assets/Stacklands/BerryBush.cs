using System.Threading.Tasks;
using UnityEngine;

namespace Stacklands
{
    public class BerryBush : MonoBehaviour
    {
        const float harvestDurationInSeconds = 2;
        
        [SerializeField] GameObject berry;

        float harvestProgressInSeconds;
        
        async void Start()
        {
            while (!destroyCancellationToken.IsCancellationRequested)
            {
                await Task.Yield();
                if (!CanStartHarvest())
                {
                    harvestProgressInSeconds = 0;
                    continue;
                }

                harvestProgressInSeconds += Time.deltaTime;
                if (harvestProgressInSeconds < harvestDurationInSeconds) 
                    continue;
                
                GenerateBerry();
                harvestProgressInSeconds = 0;
            }
        }

        void GenerateBerry()
        {
            Instantiate(berry, transform.position + Vector3.down, Quaternion.identity);
        }

        bool CanStartHarvest()
        {
            return GetComponent<Stackable>().HasSomethingStacked;
        }
    }
}