using System.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;

internal class PlayerActionChoices : MonoBehaviour
{
    public Task WaitForChoose()
    {
        SwitchTo("move");
        var cursor = FindAnyObjectByType<TargetCursor>();
        return cursor.SelectTarget();
    }

    public void SwitchTo(string what)
    {
        Assert.IsTrue(what is "attack" or "move");
        var cursor = FindAnyObjectByType<TargetCursor>();
        switch (what)
        {
            case "attack":
                cursor.DyeCursor(Color.red);
                break;
            case "move":
                cursor.DyeCursor(Color.blue);
                break;
        }
    }
}