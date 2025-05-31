using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

internal class TargetCursor : MonoBehaviour
{
    public async Task SelectTarget()
    {
        ShowCursor();
        while (!ChoseLocation())
        {
            transform.position = WhereThePlayerIsPointingTo();
            await Task.Yield();
        }
        HideCursor();

        FindAnyObjectByType<Character>()
            .GetComponent<Movimiento>()
            .Towards(WhereThePlayerIsPointingTo());
    }

    static bool ChoseLocation() => Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject();

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