using System.Threading.Tasks;
using UnityEngine;

internal class Projectile : MonoBehaviour
{
    Vector3 target;
    
    public Task HacerLoQueTengaPendiente()
    {
        return Moverse();
    }

    Task Moverse()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, 5f * Time.deltaTime);
        return Task.CompletedTask;
    }

    public void Towards(Vector3 target)
    {
        this.target = target;
    }
}