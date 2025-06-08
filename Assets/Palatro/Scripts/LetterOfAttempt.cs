using System;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

public class LetterOfAttempt : MonoBehaviour
{
    public int ExtraPoints { get; private set; }
    
    void Awake()
    {
        ToggleIsEmpty(true);
        ExtraPointsAre(ExtraPointsFromPosition(transform.GetSiblingIndex()));
    }

    public void ExtraPointsAre(int howMany)
    {
        Assert.IsTrue(howMany >= 0);

        ExtraPoints = howMany;
        var extraPointsText = transform.Find("WhenIsEmpty/ExtraPoints");
        
        extraPointsText.GetComponentInChildren<TMP_Text>().text = howMany > 0 ? "+" + howMany : "";
    }

    void ToggleIsEmpty(bool isEmpty)
    {
        var filledState = transform.Find("WhenIsFilledWithLetter");
        var emptyState = transform.Find("WhenIsEmpty");
        
        filledState.gameObject.SetActive(!isEmpty);
        emptyState.gameObject.SetActive(isEmpty);
    }

    static int ExtraPointsFromPosition(int i)
    {
        Assert.IsTrue(i is >= 0 and < 10, $"Index {i} is out of range. It should be between 1 and 9.");
        return i switch
        {
            < 4 => 0,
            5 => 2,
            6 or 7 or 8 => 5,
            9 => 10,
            _ => 0
        };
    }
}
