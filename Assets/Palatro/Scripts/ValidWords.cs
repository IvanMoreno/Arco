using System;
using UnityEngine;
using UnityEngine.Assertions;

public class ValidWords : MonoBehaviour
{
    string[] validWords;
    
    void Start()
    {
        var validWordsText = Resources.Load<TextAsset>("ValidWords");
        Assert.IsNotNull(validWordsText);
        
        validWords = validWordsText.text.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
    }
}
