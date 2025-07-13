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
        
        void FixedUpdate()
        {
            RepelOverlappingCards();
            Decelerate();
        }

        void RepelOverlappingCards()
        {
            foreach (var card in overlappingCards.Where(CanRepel))
                Repel(card);
        }

        void Decelerate()
        {
            if (IsOverlappingWithAnyCard) return;

            var rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.linearVelocity = new(Mathf.Lerp(rigidbody.linearVelocity.x, 0, Time.deltaTime * decelerationFactor),
                Mathf.Lerp(rigidbody.linearVelocity.y, 0, Time.deltaTime * decelerationFactor));
        }

        void Repel(Stackable otherStackable) 
            => otherStackable.GetComponent<Rigidbody2D>()
                .AddForce((otherStackable.transform.position - transform.position).normalized * repelForce, ForceMode2D.Force);

        static bool CanRepel(Stackable otherStackable) => !IsPartOfStack(otherStackable);
        static bool IsPartOfStack(Stackable otherStackable) => IsChildOfAnyStack(otherStackable) || IsParentOfAnyStack(otherStackable);

        // Los hijos no heredan la velocidad del rigidbody, habría que usar joints.
        // Por ahora, los stacks empujan, pero no son empujados.
        static bool IsParentOfAnyStack(Stackable otherStackable) => otherStackable.TheWholeStackOverMe.Any();
        static bool IsChildOfAnyStack(Stackable otherStackable) => otherStackable.IsStackedOverOtherCard(out _);

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent<Stackable>(out var otherStackable))
                return;
            
            overlappingCards.Add(otherStackable);
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (!other.TryGetComponent<Stackable>(out var otherStackable))
                return;

            overlappingCards.Remove(otherStackable);
        }
    }
}