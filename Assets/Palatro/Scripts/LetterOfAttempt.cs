using System;
using UnityEngine;

public class LetterOfAttempt : MonoBehaviour
{
    void Awake()
    {
        ToggleIsEmpty(true);
    }

    void ToggleIsEmpty(bool isEmpty)
    {
        var filledState = transform.Find("WhenIsFilledWithLetter");
        var emptyState = transform.Find("WhenIsEmpty");
        
        filledState.gameObject.SetActive(!isEmpty);
        emptyState.gameObject.SetActive(isEmpty);
    }
}
