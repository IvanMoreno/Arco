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
            var nearbyElements = Physics2D.OverlapCircleAll(card.transform.position, StackDetectionRadius);
            
            var eligibleStackable = from stackableCandidate in nearbyElements 
                                    where stackableCandidate.GetComponent<Card>().IsStackableOnMe(card) 
                                    select stackableCandidate.GetComponent<Stackable>();
            
            return eligibleStackable.FirstOrDefault();
        }
        
        Stackable ClosestToBeStackedOnOfSameType(Card card)
        {
            var nearbyElements = Physics2D.OverlapCircleAll(card.transform.position, StackDetectionRadius);
            
            var eligibleStackable = from stackableCandidate in nearbyElements 
                where stackableCandidate.GetComponent<Card>().IsStackableOnMe(card) 
                where stackableCandidate.GetComponent<Card>().BelongsToSameCategory(card)
                select stackableCandidate.GetComponent<Stackable>();
            
            return eligibleStackable.FirstOrDefault();
        }

        public void SpawnAt(GameObject what, Vector2 whereExactly)
        {
            Instantiate(what, whereExactly, Quaternion.identity);
        }
        
        public void SpawnNearby(GameObject what, Vector2 whereabouts)
        {
            var asd = Instantiate(what, whereabouts + Vector2.down * Card.AssumedSizeAprox.y, Quaternion.identity);

            var closest = ClosestToBeStackedOnOfSameType(asd.GetComponent<Card>());
            closest?.StackOnMe(asd.GetComponent<Stackable>());
        }
    }
}