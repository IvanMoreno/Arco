using System.Threading.Tasks;
using UnityEngine;

internal class Character : MonoBehaviour
{
    #region Algo que todavía no tenemos claro pero que se repite en enemy
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