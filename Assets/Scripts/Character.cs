using System.Threading.Tasks;
using UnityEngine;

internal class Character : MonoBehaviour
{
    #region Algo que todavía no tenemos claro pero que se repite en enemy

    public Task HacerLoQueTengaPendiente()
    {
        return GetComponent<AlgoComunEntreCharacterYEnemy>().HacerLoQueTengaPendiente();
    }
    
    public void ProgramarMovimiento(Vector3 target)
    {
        GetComponent<AlgoComunEntreCharacterYEnemy>().ProgramarMovimiento(target);
    }
    
    public void ProgramarDisparo(Vector3 target)
    {
        GetComponent<AlgoComunEntreCharacterYEnemy>().ProgramarDisparo(target);
    }

    public void RecibirImpacto()
    {
        GetComponent<AlgoComunEntreCharacterYEnemy>().RecibirImpacto();
    }

    #endregion

    public void MarkAsSelected()
    {
        GetComponentInChildren<SelectionMark>().Show();
    }

    public void UnMarkAsSelected()
    {
        GetComponentInChildren<SelectionMark>().Hide();
    }
}