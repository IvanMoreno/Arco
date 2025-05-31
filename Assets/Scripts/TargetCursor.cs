using System.Threading.Tasks;
using UnityEngine;

internal class TargetCursor : MonoBehaviour
{
    public async Task SelectTarget()
    {
        ShowCursor();
        while (!Input.GetMouseButtonDown(0))
        {
            transform.position = WhereThePlayerIsPointingTo();
            await Task.Yield();
        }
        HideCursor();

        FindAnyObjectByType<Character>()
            .GetComponent<Movimiento>()
            .Towards(WhereThePlayerIsPointingTo());
    }

    void ShowCursor()
    {
        GetComponentInChildren<SpriteRenderer>().enabled = true;
    }
    
    void HideCursor()
    {
        GetComponentInChildren<SpriteRenderer>().enabled = false;
    }

    static Vector3 WhereThePlayerIsPointingTo()
    {
        var mousePosition = Input.mousePosition;
        var positionInWorld = Camera.main.ScreenToWorldPoint(mousePosition);
        positionInWorld.z = 0;
        return positionInWorld;
    }
}