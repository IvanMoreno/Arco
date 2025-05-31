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
        GetComponent<Vida>().UnaMenos();
        if (GetComponent<Vida>().EstaMuerto())
            Destroy(gameObject);
    }
}