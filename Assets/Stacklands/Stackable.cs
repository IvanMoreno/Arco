using NUnit.Framework;
using UnityEngine;

namespace Stacklands
{
    public class Stackable : MonoBehaviour
    {
        Stackable stackedOverMe;
        
        public bool HasSomethingStacked => stackedOverMe != null;
        
        public void StackOnMe(Stackable other)
        {
            Assert.IsNotNull(other);
            Assert.AreNotEqual(this, other);
            Assert.IsFalse(HasSomethingStacked);

            stackedOverMe = other;
            
            other.transform.position = transform.position + Vector3.down * 0.25f;
            other.transform.SetParent(transform);
        }

        public void StackOver(Stackable other) => other.StackOnMe(this);

        public void RemoveFromStack()
        {
            if (transform.parent == null || !transform.parent.TryGetComponent<Stackable>(out var parent))
                return;

            parent.stackedOverMe = null;
            transform.SetParent(null);
        }
    }
}