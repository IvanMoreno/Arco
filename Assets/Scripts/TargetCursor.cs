using System.Threading.Tasks;
using UnityEngine;

internal class TargetCursor : MonoBehaviour
{
    public async Task SelectTarget()
    {
        while (!Input.GetMouseButtonDown(0))
        {
            await Task.Yield();
        }

        var character = FindAnyObjectByType<Character>().GetComponent<Movimiento>();
        character.Hacia(Donde(character));
    }

    static Vector3 Donde(Movimiento character)
    {
        var mousePosition = Input.mousePosition;
        var positionInWorld = Camera.main.ScreenToWorldPoint(mousePosition);
        positionInWorld.z = character.transform.position.z;
        return positionInWorld;
    }
}