using System.Threading.Tasks;
using UnityEngine;

internal class Turn : MonoBehaviour
{
    int turn;

    async void Start()
    {
        await CosasAntesDelPrimerTurno();
        while (!destroyCancellationToken.IsCancellationRequested)
            await OneTurn();
    }

    async Task CosasAntesDelPrimerTurno()
    {
    }

    async Task OneTurn()
    {
        turn++;
        await EnseñarLasPredicciones();
        await ChooseAction();
        await EsconderLasPredicciones();
        
        await EjecutarLasAccionesPendientes();
    }

    async Task EsconderLasPredicciones()
    {
        foreach (var spawner in FindObjectsByType<Spawner>((FindObjectsSortMode)FindObjectsInactive.Exclude))
        {
            await spawner.HidePrediction();
        }
    }

    async Task EnseñarLasPredicciones()
    {
        foreach (var spawner in FindObjectsByType<Spawner>((FindObjectsSortMode)FindObjectsInactive.Exclude))
        {
            await spawner.ShowPrediction(turn);
        }
    }

    async Task ChooseAction()
    {
        await FindAnyObjectByType<TargetCursor>().SelectTarget();
    }

    async Task EjecutarLasAccionesPendientes()
    {
        await SpawnEnemies();
        await FindAnyObjectByType<Character>().HacerLoQueTengaPendiente();
        foreach (var enemy in FindObjectsByType<Enemy>((FindObjectsSortMode)FindObjectsInactive.Exclude))
        {
            await enemy.HacerLoQueTengaPendiente();
        }
    }

    async Task SpawnEnemies()
    {
        foreach (var spawner in FindObjectsByType<Spawner>((FindObjectsSortMode)FindObjectsInactive.Exclude))
        {
            await spawner.ApareceSiEsElTurno(turn);
        }
    }
}