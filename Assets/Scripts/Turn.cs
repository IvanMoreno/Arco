using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

internal class Turn : MonoBehaviour
{
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
        await FindAnyObjectByType<Character>().HacerLoQueTengaPendiente();
    }
}