using System.Threading.Tasks;
using UnityEngine;

internal class Disparo : MonoBehaviour, Intent
{
    [SerializeField] GameObject projectilePrefab;

    public Vector3 Target { get; private set; }

    public async Task Hacerse()
    {
        var projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().Towards(Target);
    }
    
    public void Towards(Vector3 target) => this.Target = target;
}