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
        FindAnyObjectByType<Canvas>().enabled = false;
    }

    async Task OneTurn()
    {
        turn++;
        await ShowPredictions();
        await EsperarAQueElJugadorHagaLoQueQuiera();
        await HidePredictions();
        
        await EjecutarLasAccionesPendientes();
    }

    async Task HidePredictions()
    {
        foreach (var spawner in FindObjectsByType<Spawner>(None))
        {
            await spawner.HidePrediction();
        }
        
        foreach (var enemy in FindObjectsByType<Enemy>(None))
        {
            await enemy.HidePrediction();
        }
    }

    async Task ShowPredictions()
    {
        foreach (var spawner in FindObjectsByType<Spawner>(None))
        {
            await spawner.ShowPrediction(turn);
        }
        
        foreach (var enemy in FindObjectsByType<Enemy>(None))
        {
            await enemy.ShowPrediction();
        }
    }

    async Task EsperarAQueElJugadorHagaLoQueQuiera()
    {
        FindAnyObjectByType<Canvas>().enabled = true;
        await FindAnyObjectByType<PlayerActionChoices>().WaitForChoose();
        FindAnyObjectByType<Canvas>().enabled = false;
    }

    Task EjecutarLasAccionesPendientes()
    {
        return Task.WhenAll(Characters(), Enemies(), Projectiles(), Spawners());
    }

    static async Task Characters()
    {
        await FindAnyObjectByType<Character>().HacerLoQueTengaPendiente();
    }

    static async Task Enemies()
    {
        foreach (var enemy in FindObjectsByType<Enemy>(None))
        {
            await enemy.HacerLoQueTengaPendiente();
        }
    }

    static Task Projectiles()
    {
        var tasks = FindObjectsByType<Projectile>(None).Select(projectile => projectile.HacerLoQueTengaPendiente());
        return Task.WhenAll(tasks);
    }

    async Task Spawners()
    {
        foreach (var spawner in FindObjectsByType<Spawner>(None))
        {
            await spawner.SpawnIfIn(turn);
        }
    }
}