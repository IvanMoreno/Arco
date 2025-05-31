using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

internal class Turn : MonoBehaviour
{
    async void Start()
    {
        await CosasAntesDelPrimerTurno();
        int turn = 0;
        while (!destroyCancellationToken.IsCancellationRequested)
        {
            await SpawnEnemies(turn++);
            await OneTurn();
        }
    }

    async Task SpawnEnemies(int turn)
    {
        foreach (var spawner in FindObjectsByType<Spawner>((FindObjectsSortMode)FindObjectsInactive.Exclude))
        {
            await spawner.ApareceSiEsElTurno(turn);
        }
    }

    async Task CosasAntesDelPrimerTurno()
    {
    }

    async Task OneTurn()
    {
        await EnseñarLasPredicciones();
        await ChooseAction();
        await EsconderLasPredicciones();
        
        await EjecutarLasAccionesPendientes();
    }

    async Task EsconderLasPredicciones() { }
    async Task EnseñarLasPredicciones() { }

    async Task ChooseAction()
    {
        await FindAnyObjectByType<TargetCursor>().SelectTarget();
    }

    async Task EjecutarLasAccionesPendientes()
    {
        await FindAnyObjectByType<Character>().HacerLoQueTengaPendiente();
        await FindAnyObjectByType<Enemy>().HacerLoQueTengaPendiente();
    }
}