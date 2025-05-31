using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.FindObjectsSortMode;

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
        await ShowPredictions();
        await ChooseAction();
        await HidePredictions();
        
        await EjecutarLasAccionesPendientes();
    }

    async Task HidePredictions()
    {
        foreach (var spawner in FindObjectsByType<Spawner>((FindObjectsSortMode)FindObjectsInactive.Exclude))
        {
            await spawner.HidePrediction();
        }
    }

    async Task ShowPredictions()
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

    Task EjecutarLasAccionesPendientes()
    {
        return Task.WhenAll(ComportamientoPersonaje(), ComportamientoEnemigos(), MoveProjectiles(), SpawnEnemies());
    }

    static async Task ComportamientoPersonaje()
    {
        await FindAnyObjectByType<Character>().HacerLoQueTengaPendiente();
    }

    static async Task ComportamientoEnemigos()
    {
        foreach (var enemy in FindObjectsByType<Enemy>(None))
        {
            await enemy.HacerLoQueTengaPendiente();
        }
    }

    static Task MoveProjectiles()
    {
        var tasks = FindObjectsByType<Projectile>(None).Select(projectile => projectile.HacerLoQueTengaPendiente());
        return Task.WhenAll(tasks);
    }

    async Task SpawnEnemies()
    {
        foreach (var spawner in FindObjectsByType<Spawner>((FindObjectsSortMode)FindObjectsInactive.Exclude))
        {
            await spawner.SpawnIfIn(turn);
        }
    }
}