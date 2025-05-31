using UnityEngine;

internal class SelectionMark : MonoBehaviour
{
    public void Show()
    {
        GetComponent<SpriteRenderer>().enabled = true;
    }

    public void Hide()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }
}