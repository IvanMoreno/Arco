using System.Threading.Tasks;
using UnityEngine;

namespace Stacklands
{
    public class BerryBush : MonoBehaviour
    {
        [SerializeField] GameObject berry;
        
        async void Start()
        {
            while (!CanStartHarvest())
            {
                await Task.Yield();
            }

            GenerateBerry();
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