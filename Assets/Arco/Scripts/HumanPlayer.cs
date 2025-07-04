﻿using System.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;

internal class HumanPlayer : MonoBehaviour, Brain
{
    string selectedChoice;
    
    public async Task Think()
    {
        SwitchTo("move");
        FindAnyObjectByType<SelectedCharacterIntent>().onChoiceSelected += SwitchTo;
        
        GetComponent<Somebody>().GetComponentInChildren<SelectionMark>().Show();
        await ChooseFor(GetComponent<Somebody>().GetComponent<Somebody>());
        GetComponent<Somebody>().GetComponentInChildren<SelectionMark>().Hide();
        
        FindAnyObjectByType<SelectedCharacterIntent>().onChoiceSelected -= SwitchTo;
    }

    async Task ChooseFor(Somebody character)
    {
        var targetPosition = await FindAnyObjectByType<TargetCursor>().SelectTargetPosition(GetComponent<CharacterPrediction>());

        if(selectedChoice == "move")
            character.ProgramarMovimiento(targetPosition);
        else if(selectedChoice == "attack")
            character.ProgramarDisparo(targetPosition);
    }

    public void SwitchTo(string what)
    {
        Assert.IsTrue(what is "attack" or "move");

        GetComponent<CharacterPrediction>().DyePrediction(ColorOf(what));
        FindAnyObjectByType<TargetCursor>().DyeCursor(ColorOf(what));
        selectedChoice = what;
        
        Assert.IsFalse(string.IsNullOrEmpty(selectedChoice));
    }

    static Color ColorOf(string action)
    {
        return action switch
        {
            "move" => Color.cyan,
            "attack" => Color.red,
            _ => throw new System.ArgumentException($"Unknown action: {action}")
        };
    }
}