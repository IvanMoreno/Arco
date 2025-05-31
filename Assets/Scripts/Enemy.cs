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

        //instantiate a projectile and move it towards the character
        var projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().Towards(posPersonaje);
    }

    Task Moverse()
    {
        GetComponent<Movimiento>().Hacia((Vector2)transform.position + Random.insideUnitCircle);
        return GetComponent<Movimiento>().Hacerse();
    }
}