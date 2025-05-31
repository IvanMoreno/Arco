using System;
using System.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;

internal class Choose : MonoBehaviour
{
    string selectedChoice;
    
    public async Task WaitForChoose(Character character)
    {
        SwitchTo("move");
        
        character.GetComponentInChildren<SelectionMark>().Show();
        await ChooseFor(character.GetComponent<Somebody>());
        character.GetComponentInChildren<SelectionMark>().Hide();
    }

    async Task ChooseFor(Somebody character)
    {
        var targetPosition = await FindAnyObjectByType<TargetCursor>().SelectTargetPosition();

        if(selectedChoice == "move")
            character.ProgramarMovimiento(targetPosition);
        else if(selectedChoice == "attack")
            character.ProgramarDisparo(targetPosition);
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