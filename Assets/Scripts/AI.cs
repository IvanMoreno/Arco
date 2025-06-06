﻿using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

internal class AI : MonoBehaviour, Brain
{
    public Task Think()
    {
        var enemy = GetComponent<Somebody>();
        var willAttackInThisTurn = Random.value >= 0.5f;
        var movementPosition = (Vector2)enemy.transform.position + Random.insideUnitCircle * 3;
        var targetPosition = willAttackInThisTurn ? RandomCharacterPosition() : movementPosition;
        if (!willAttackInThisTurn)
            enemy.ProgramarMovimiento(targetPosition);
        else
            enemy.ProgramarDisparo(targetPosition);
        
        return Task.CompletedTask;
    }
    
    static Vector2 RandomCharacterPosition()
    {
        var allCharacters = FindObjectsByType<Somebody>(FindObjectsSortMode.None).Where(x => !x.IsEnemy).ToArray();
        return allCharacters[Random.Range(0, allCharacters.Length)].transform.position;
    }
}