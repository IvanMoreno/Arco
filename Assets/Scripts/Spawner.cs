using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

internal class Spawner : MonoBehaviour
{
    [SerializeField] int turn;
    [SerializeField] Enemy enemyPrefab;

    public async Task ApareceSiEsElTurno(int turn)
    {
        if (this.turn == turn)
        {
            Instantiate(enemyPrefab, transform);
        }
    }

    public async Task ShowPrediction(int turn)
    {
        GetComponentInChildren<SpriteRenderer>(true).GameObject().SetActive(turn == this.turn);
    }

    public async Task HidePrediction()
    {
        GetComponentInChildren<SpriteRenderer>(true).GameObject().SetActive(false);
    }
}