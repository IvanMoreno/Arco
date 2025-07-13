using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Stacklands
{
    public class RepelCardsByCollision : MonoBehaviour
    {
        [SerializeField] float repelForce = 3;
        [SerializeField] float decelerationFactor = 2;
        
        readonly HashSet<Stackable> overlappingCards = new();
        bool IsOverlappingWithAnyCard => overlappingCards.Any();
        
        void Update()
        {
            if (!IsOverlappingWithAnyCard)
            {
                var rigidbody = GetComponent<Rigidbody2D>();
                rigidbody.linearVelocity = new(Mathf.Lerp(rigidbody.linearVelocity.x, 0, Time.deltaTime * decelerationFactor),
                    Mathf.Lerp(rigidbody.linearVelocity.y, 0, Time.deltaTime * decelerationFactor));
            }
        }

        void OnTriggerStay2D(Collider2D other)
        {
            if (!other.TryGetComponent<Stackable>(out var otherStackable))
                return;
            
            if (otherStackable.IsStackedOverOtherCard(out _))
                return;

            var myCardStackable = GetComponent<Stackable>();
            if (myCardStackable.TheWholeStackOverMe.Contains(otherStackable))
                return;

            if (myCardStackable.IsStackedOverOtherCard(out var parent) &&
                parent.gameObject == otherStackable.gameObject)
                return;

            overlappingCards.Add(otherStackable);
            
            // Los hijos no heredan la velocidad del rigidbody, habría que usar joints.
            // Por ahora, los stacks empujan, pero no son empujados.
            if (otherStackable.TheWholeStackOverMe.Any())
                return;

            otherStackable.GetComponent<Rigidbody2D>()
                .AddForce((otherStackable.transform.position - transform.position).normalized * repelForce, ForceMode2D.Force);
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (!other.TryGetComponent<Stackable>(out var otherStackable))
                return;

            overlappingCards.Remove(otherStackable);
        }
    }
}