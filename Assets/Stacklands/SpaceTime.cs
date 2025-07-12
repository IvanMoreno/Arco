using System.Collections.Generic;
using System.Linq;
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
                where stackableCandidate.GetComponent<Card>().IsStackableOnMe(card)
                select stackableCandidate.GetComponent<Stackable>();
        }

        public void SpawnAt(GameObject what, Vector2 whereExactly)
        {
            Instantiate(what, whereExactly, Quaternion.identity);
        }
        
        public void SpawnNearbyCard(GameObject what, Vector2 whereabouts)
        {
            var newCard = Instantiate(what, whereabouts + Vector2.down * Card.AssumedSizeAprox.y, Quaternion.identity);

            var closest = ClosestToBeStackedOnOfSameType(newCard.GetComponent<Card>());
            closest?.StackOnMe(newCard.GetComponent<Stackable>());
        }
    }
}