using System.Threading.Tasks;
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
}