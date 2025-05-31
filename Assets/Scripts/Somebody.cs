using System.Threading.Tasks;
using UnityEngine;

internal class Somebody : MonoBehaviour
{
    [field: SerializeField] public bool IsEnemy { get; private set; }

    Intent intent;
    
    public bool WillAttack => intent is Disparo;

    public Task HacerLoQueTengaPendiente()
    {
        return intent.Hacerse();
    }

    public void ProgramarMovimiento(Vector3 target)
    {
        GetComponent<Movimiento>().Towards(target);
        intent = GetComponent<Movimiento>();
    }
    
    public void ProgramarDisparo(Vector3 target)
    {
        intent = GetComponent<Disparo>();
        GetComponent<Disparo>().Towards(target);
    }

    public void RecibirImpacto()
    {
        GetComponent<Vida>().UnaMenos();
        if (GetComponent<Vida>().EstaMuerto())
            Destroy(gameObject);
    }
}