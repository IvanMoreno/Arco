using System.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;

internal class PlayerActionChoices : MonoBehaviour
{
    string selectedChoice;
    
    public Task WaitForChoose()
    {
        SwitchTo("move");
        var cursor = FindAnyObjectByType<TargetCursor>();
        return cursor.SelectTarget();
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