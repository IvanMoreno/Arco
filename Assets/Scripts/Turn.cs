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
        await EsperarAQueEnemigosDecidan();
        await ShowPredictions();
        await EsperarAQueElJugadorHagaLoQueQuiera();
        await HidePredictions();
        
        await EjecutarLasAccionesPendientes();
    }

    async Task EsperarAQueEnemigosDecidan()
    {
        foreach (var enemy in FindObjectsByType<Somebody>(None).Where(x => x.IsEnemy))
        {
            await enemy.Choose();
        }
    }

    async Task HidePredictions()
    {
        foreach (var spawner in FindObjectsByType<Spawner>(None))
        {
            await spawner.HidePrediction();
        }
        
        foreach (var prediction in FindObjectsByType<Prediction>(None))
        {
            await prediction.Hide();
        }
    }

    async Task ShowPredictions()
    {
        foreach (var spawner in FindObjectsByType<Spawner>(None))
        {
            await spawner.ShowPrediction(turn);
        }
        
        foreach (var prediction in FindObjectsByType<Prediction>(None))
        {
            await prediction.Show();
        }
    }

    async Task EsperarAQueElJugadorHagaLoQueQuiera()
    {
        FindAnyObjectByType<Canvas>().enabled = true;
        await PlanearAccionesDeLosPersonajes();
        FindAnyObjectByType<Canvas>().enabled = false;
    }

    static async Task PlanearAccionesDeLosPersonajes()
    {
        foreach (var character in AllCharacters())
            await character.Choose();
    }

    static IEnumerable<Somebody> AllCharacters()
    {
        return FindObjectsByType<Somebody>(None).Where(somebody => !somebody.IsEnemy);
    }

    Task EjecutarLasAccionesPendientes()
    {
        return Task.WhenAll(Characters(), Enemies(), Projectiles(), Spawners());
    }

    static async Task Characters()
    {
        var tasks = AllCharacters().Select(x => x.HacerLoQueTengaPendiente());
        await Task.WhenAll(tasks);
    }

    static Task Enemies()
    {
        var tasks = FindObjectsByType<Somebody>(None).Where(x => x.IsEnemy).Select(enemy => enemy.HacerLoQueTengaPendiente());
        return Task.WhenAll(tasks);
    }

    static Task Projectiles()
    {
        var tasks = FindObjectsByType<ProjectileOfEnemy>(None).Select(projectile => projectile.HacerLoQueTengaPendiente());
        tasks = tasks.Concat(FindObjectsByType<ProjectileOfCharacter>(None).Select(projectile => projectile.HacerLoQueTengaPendiente()));
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