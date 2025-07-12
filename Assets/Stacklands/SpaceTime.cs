using System.Linq;
using UnityEngine;

namespace Stacklands
{
    public class SpaceTime : MonoBehaviour
    {
        [SerializeField] float stackDetectionRadius = 2;

        //aquí van a ir las cosas también del tiempo que ahora mismo están en la luna. :)

        public Stackable ClosestToBeStackedOn(Card card)
        {
            var nearbyElements = Physics2D.OverlapCircleAll(card.transform.position, stackDetectionRadius);
            
            var eligibleStackable = from stackableCandidate in nearbyElements 
                                    where stackableCandidate.GetComponent<Card>().IsStackableOnMe(card) 
                                    select stackableCandidate.GetComponent<Stackable>();
            
            return eligibleStackable.FirstOrDefault();
        }

        public void SpawnAt(GameObject what, Vector2 whereExactly)
        {
            Instantiate(what, whereExactly, Quaternion.identity);
        }
        public void SpawnNearby(GameObject what, Vector2 whereabouts)
        {
            Instantiate(what, whereabouts + Vector2.down * Card.AssumedSizeAprox.y, Quaternion.identity);
        }
    }
}