using System.Threading.Tasks;
using UnityEngine;

internal class TargetCursor : MonoBehaviour
{
    public async Task SelectTarget()
    {
        while (!Input.GetMouseButtonDown(0))
        {
            transform.position = WhereThePlayerIsPointingTo();
            await Task.Yield();
        }

        FindAnyObjectByType<Character>()
            .GetComponent<Movimiento>()
            .Towards(WhereThePlayerIsPointingTo());
    }

    static Vector3 WhereThePlayerIsPointingTo()
    {
        var mousePosition = Input.mousePosition;
        var positionInWorld = Camera.main.ScreenToWorldPoint(mousePosition);
        positionInWorld.z = 0;
        return positionInWorld;
    }
}