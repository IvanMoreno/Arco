using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace Palatro
{
    public class ValidWords : MonoBehaviour
    {
        [SerializeField, Tooltip("Only for QA purposes")] string testSomeWord; 
        
        IReadOnlyList<string> validWordsAllUppercase;
    
        void Start()
        {
            var validWordsText = Resources.Load<TextAsset>("ValidWords");
            Assert.IsNotNull(validWordsText);
        
            validWordsAllUppercase = validWordsText.text
                .Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.TrimEnd('\r'))
                .Select(x => x.ToUpperInvariant()).ToList();
            
            Assert.IsTrue(validWordsAllUppercase.Any());
        }

        public bool Whether(Word attempt) => Whether(attempt.Shape);

        public bool Whether(string attempt)
        {
            Assert.IsNotNull(validWordsAllUppercase);
            Assert.IsNotNull(attempt, "Esto no lo tengo muy claro...");
            
            var normalizedAttempt = attempt.ToUpperInvariant();
            return validWordsAllUppercase.Contains(normalizedAttempt);
        }

        void OnValidate()
        {
            if (string.IsNullOrEmpty(testSomeWord))
                return;
            
            Debug.Log($"¿La palabra '{testSomeWord}' es válida?: {Whether(testSomeWord)}", this);
        }
    }
}