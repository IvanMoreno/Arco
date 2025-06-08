using System.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;

internal class Spawner : MonoBehaviour
{
    [SerializeField] int turn;
    [SerializeField] Somebody enemyPrefab;

    public async Task SpawnIfIn(int turn)
    {
        if (this.turn == turn)
        {
            Assert.IsTrue(enemyPrefab.IsEnemy);
            Instantiate(enemyPrefab, transform);
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