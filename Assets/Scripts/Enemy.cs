using System.Threading.Tasks;
using UnityEngine;

internal class Enemy : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    
    public Task HacerLoQueTengaPendiente()
    {
        return Random.value < 0.5f ? Moverse() : DispararHaciaElPersonaje();
    }

    async Task DispararHaciaElPersonaje()
    {
        var posPersonaje = FindAnyObjectByType<Character>().transform.position;

        var projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.transform.up = (posPersonaje - transform.position).normalized;
    }

    Task Moverse()
    {
        GetComponent<Movimiento>().Hacia((Vector2)transform.position + Random.insideUnitCircle);
        return GetComponent<Movimiento>().Hacerse();
    }
}