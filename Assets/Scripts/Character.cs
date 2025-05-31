using System.Threading.Tasks;
using UnityEngine;

internal class Character : MonoBehaviour
{
    public Task HacerLoQueTengaPendiente()
    {
        return GetComponent<Movimiento>().Hacerse();
    }
    
    public void RecibirImpacto()
    {
        Destroy(gameObject);
    }
}