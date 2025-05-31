using System.Threading.Tasks;
using UnityEngine;

internal class ProjectileOfEnemy : MonoBehaviour, Projectile
{
    [SerializeField] float distancePerTurn = 2;
    [SerializeField] float speed = 10;
    
    public Task HacerLoQueTengaPendiente()
    {
        return Moverse();
    }

    async Task Moverse()
    {
        var targetPosition = TargetPosition();
        while (!CumpleCondicionDelTurno(targetPosition))
        {
            transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
            await Task.Yield();
        }
    }

    bool CumpleCondicionDelTurno(Vector3 targetPosition) => Vector3.Distance(transform.position, targetPosition) <= 0.1f;
    Vector3 TargetPosition() => transform.position + transform.up * distancePerTurn;

    public void Towards(Vector3 target)
    {
        transform.up = (target - transform.position).normalized;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var candidateCharacter = other.GetComponent<Somebody>();
        if (candidateCharacter is { IsAutomatic: true })
            return;

        candidateCharacter.RecibirImpacto();
        DestroyMe();
    }

    void DestroyMe()
    {
        //Todavía no lo hacemos porque da una MissingException si se destruye.
    }
}