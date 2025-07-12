using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

namespace Stacklands
{
    public class Stackable : MonoBehaviour
    {
        [SerializeField] AudioClip onStacked;
        
        Stackable stackedOverMe;
        
        public bool HasSomethingStacked => stackedOverMe != null;

        public StackOfCards TheWholeStackOverMe
        {
            get
            {
                if (stackedOverMe == null) 
                    return StackOfCards.Empty();
                
                var result = new List<Stackable> { stackedOverMe };
                result.AddRange(stackedOverMe.TheWholeStackOverMe);
                return new(result);
            }
        }
        
        public void StackOnMe(Stackable other)
        {
            Assert.IsNotNull(other);
            Assert.AreNotEqual(this, other);
            Assert.IsFalse(HasSomethingStacked);
            Assert.AreNotEqual(other.stackedOverMe, this);

            stackedOverMe = other;
            
            other.transform.position = transform.position + Vector3.down * Card.AssumedSizeAprox.y / 3f;
            other.transform.SetParent(transform);
            
            GetComponent<AudioSource>().PlayWithPitch(onStacked);
        }

        public void RemoveFromStack()
        {
            if (transform.parent == null || !transform.parent.TryGetComponent<Stackable>(out var parent))
                return;

            transform.SetParent(null);
            parent.stackedOverMe = null;
        }
    }
}