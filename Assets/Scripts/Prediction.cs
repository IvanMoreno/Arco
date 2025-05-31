using System.Threading.Tasks;
using UnityEngine;

internal class Prediction : MonoBehaviour
{
    [SerializeField] GameObject attackPrediction;
    [SerializeField] GameObject movementPrediction;

    public async Task Show()
    {
        attackPrediction.SetActive(GetComponent<Somebody>().WillAttack);
        movementPrediction.SetActive(!GetComponent<Somebody>().WillAttack);
    }

    public async Task Hide()
    {
        attackPrediction.SetActive(false);
        movementPrediction.SetActive(false);
    }
}