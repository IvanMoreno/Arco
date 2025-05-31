using System.Threading.Tasks;
using UnityEngine;

internal class Enemy : MonoBehaviour
{
    public Task HacerLoQueTengaPendiente()
    {
        GetComponent<Movimiento>().Hacia((Vector2)transform.position + Random.insideUnitCircle);
        return GetComponent<Movimiento>().Hacerse();
    }
}