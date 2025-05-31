using System.Threading.Tasks;
using UnityEngine;

internal class Enemy : MonoBehaviour
{
    public Task HacerLoQueTengaPendiente()
    {
        return GetComponent<Movimiento>().Hacerse();
    }
}