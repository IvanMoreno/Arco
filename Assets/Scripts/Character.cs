using System.Threading.Tasks;
using UnityEngine;

internal class Character : MonoBehaviour
{
    bool willAttackInThisTurn;
    
    public Task HacerLoQueTengaPendiente()
    {
        return willAttackInThisTurn ? GetComponent<Disparo>().Hacerse() : GetComponent<Movimiento>().Hacerse();
    }

    public void ProgramarMovimiento(Vector3 target)
    {
        willAttackInThisTurn = false;
        GetComponent<Movimiento>().Towards(target);
    }
    
    public void ProgramarDisparo(Vector3 target)
    {
        willAttackInThisTurn = true;
        GetComponent<Disparo>().Towards(target);
    }
    
    public void RecibirImpacto()
    {
        GetComponent<Vida>().UnaMenos();
        if (GetComponent<Vida>().EstaMuerto())
            Destroy(gameObject);
    }

    public void MarkAsSelected()
    {
        GetComponentInChildren<SelectionMark>().Show();
    }

    public void UnMarkAsSelected()
    {
        GetComponentInChildren<SelectionMark>().Hide();
    }
}