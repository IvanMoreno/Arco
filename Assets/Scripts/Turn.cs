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
        await SpawnEnemies(++turn);
        await FindAnyObjectByType<Character>().HacerLoQueTengaPendiente();
        await FindAnyObjectByType<Enemy>().HacerLoQueTengaPendiente();
    }

    async Task SpawnEnemies(int turn)
    {
        foreach (var spawner in FindObjectsByType<Spawner>((FindObjectsSortMode)FindObjectsInactive.Exclude))
        {
            await spawner.ApareceSiEsElTurno(turn);
        }
    }
}