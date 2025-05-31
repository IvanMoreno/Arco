using System.Threading.Tasks;
using UnityEngine;

internal class AI : MonoBehaviour
{
    public Task ChooseFor(Somebody enemy)
    {
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
        var allCharacters = FindObjectsByType<Character>(FindObjectsSortMode.None);
        return allCharacters[Random.Range(0, allCharacters.Length)].transform.position;
    }
}