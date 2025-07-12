using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

namespace Stacklands
{
    public class Stackable : MonoBehaviour
    {
        Stackable stackedOverMe;
        
        public bool HasSomethingStacked => stackedOverMe != null;

        public IEnumerable<Stackable> StackableOverMe
        {
            get
            {
                if (stackedOverMe == null) 
                    return Enumerable.Empty<Stackable>();
                
                var result = new List<Stackable> { stackedOverMe };
                result.AddRange(stackedOverMe.StackableOverMe);
                return result;
            }
        }
        
        public void StackOnMe(Stackable other)
        {
            Assert.IsNotNull(other);
            Assert.AreNotEqual(this, other);
            Assert.IsFalse(HasSomethingStacked);

            stackedOverMe = other;
            
            other.transform.position = transform.position + Vector3.down * Card.AssumedSizeAprox.y / 3f;
            other.transform.SetParent(transform);
        }

        public void StackOver(Stackable other) => other.StackOnMe(this);

        public void RemoveFromStack()
        {
            if (transform.parent == null || !transform.parent.TryGetComponent<Stackable>(out var parent))
                return;

            transform.SetParent(null);
            parent.stackedOverMe = null;
        }
    }
}