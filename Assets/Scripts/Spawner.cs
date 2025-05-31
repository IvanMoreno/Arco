using System.Threading.Tasks;
using UnityEngine;

internal class Spawner : MonoBehaviour
{
    [SerializeField] int turn;
    [SerializeField] Enemy enemyPrefab;

    public async Task SpawnIfIn(int turn)
    {
        if (this.turn == turn)
        {
            await InstantiateAsync(enemyPrefab, transform);
        }
    }

    public async Task ShowPrediction(int turn)
    {
        GetComponentInChildren<SpriteRenderer>(true).gameObject.SetActive(turn == this.turn);
    }

    public async Task HidePrediction()
    {
        GetComponentInChildren<SpriteRenderer>(true).gameObject.SetActive(false);
    }
}