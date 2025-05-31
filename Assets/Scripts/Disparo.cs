using System.Threading.Tasks;
using UnityEngine;

internal class Disparo : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;

    Vector3 target;

    public async Task Hacerse()
    {
        var projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().Towards(target);
    }
    
    public void Towards(Vector3 target) => this.target = target;
}