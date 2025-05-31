using System;
using System.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;

internal class PlayerActionChoices : MonoBehaviour
{
    string selectedChoice;
    
    public async Task WaitForChoose()
    {
        SwitchTo("move");

        var targetPosition = await FindAnyObjectByType<TargetCursor>().SelectTargetPosition();
        
        if(selectedChoice == "move")
            FindAnyObjectByType<Character>()
                .GetComponent<Movimiento>()
                .Towards(targetPosition);
        else if(selectedChoice == "attack")
            Debug.LogError("doing an attack is not implemented yet");
    }

    public void SwitchTo(string what)
    {
        Assert.IsTrue(what is "attack" or "move");
        
        FindAnyObjectByType<TargetCursor>().DyeCursor(ColorOf(what));
        selectedChoice = what;
        
        Assert.IsFalse(string.IsNullOrEmpty(selectedChoice));
    }

    static Color ColorOf(string action)
    {
        return action switch
        {
            "move" => Color.blue,
            "attack" => Color.red,
            _ => throw new System.ArgumentException($"Unknown action: {action}")
        };
    }
}