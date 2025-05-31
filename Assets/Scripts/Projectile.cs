using System.Threading.Tasks;
using UnityEngine;

internal class Projectile : MonoBehaviour
{
    public Task HacerLoQueTengaPendiente()
    {
        return Moverse();
    }

    Task Moverse()
    {
        transform.Translate(transform.up);
        return Task.CompletedTask;
    }
}