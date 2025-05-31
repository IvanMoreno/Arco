using System.Threading.Tasks;
using UnityEngine;

internal class Projectile : MonoBehaviour
{
    public Task HacerLoQueTengaPendiente()
    {
        return Moverse();
    }

    async Task Moverse()
    {
        transform.Translate(transform.up * 2, Space.World);
        
    }

    public void Towards(Vector3 target)
    {
        transform.up = (target - transform.position).normalized;
    }
}