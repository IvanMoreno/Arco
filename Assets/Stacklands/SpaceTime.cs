using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

namespace Stacklands
{
    public class SpaceTime : MonoBehaviour
    {
        static readonly float StackDetectionRadius = Card.AssumedSizeAprox.y / 2f;

        //aquí van a ir las cosas también del tiempo que ahora mismo están en la luna. :)

        public Stackable ClosestToBeStackedOn(Card card)
        {
            return EligibleStackable(card).FirstOrDefault();
        }

        Stackable ClosestToBeStackedOnOfSameType(Card card)
        {
            return EligibleStackable(card)
                .FirstOrDefault(x => x.GetComponent<Card>().BelongsToSameCategory(card));
        }

        static IEnumerable<Stackable> EligibleStackable(Card card)
        {
            var nearbyElements = Physics2D.OverlapCircleAll(card.transform.position, StackDetectionRadius);

            return from stackableCandidate in nearbyElements
                where IsStackableOn(stackableCandidate, card)
                select stackableCandidate.GetComponent<Stackable>();
        }

        static bool IsStackableOn(Collider2D root, Card card)
        {
            if (!root.TryGetComponent<Card>(out var rootCard))
                return false;
            
            return rootCard.IsStackableOnMe(card);
        }

        public void SpawnAt(GameObject what, Vector2 whereExactly)
        {
            Spawn(what, whereExactly);
        }

        public void SpawnNearbyCard(GameObject what, Vector2 whereabouts)
        {
            var newCard = Spawn(what, whereabouts + Vector2.down * Card.AssumedSizeAprox.y);

            var closest = ClosestToBeStackedOnOfSameType(newCard.GetComponent<Card>());
            closest?.StackOnMe(newCard.GetComponent<Stackable>());
        }

        GameObject Spawn(GameObject what, Vector2 whereExactly)
        {
            var instance = Instantiate(what, whereExactly, Quaternion.identity, transform);
            
            var alwaysOnTop = instance.GetComponent<AlwaysOnTop>();
            Assert.NotNull(alwaysOnTop, "Spawned object must have a Card component.");
            alwaysOnTop.BringForward();
            
            return instance;
        }
    }
}