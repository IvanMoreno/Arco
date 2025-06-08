using System;
using NUnit.Framework;
using UnityEngine;

internal class SelectedCharacterIntent : MonoBehaviour
{
    public Action<string> onChoiceSelected { get; set; }
    string selectedChoice;
    
    public void SwitchTo(string what)
    {
        Assert.IsTrue(what is "attack" or "move");

        selectedChoice = what;
        onChoiceSelected?.Invoke(selectedChoice);
        Assert.IsFalse(string.IsNullOrEmpty(selectedChoice));
    }
}