using UnityEngine;

namespace Stacklands
{
    public class DragDropCard : MonoBehaviour
    {
        [SerializeField] float stackDetectionRadius = 2;
        
        public void OnMouseDown()
        {
            GetComponent<Stackable>().RemoveFromStack();
        }

        public void OnMouseUp()
        {
            StackOnNearestCard();
        }

        void StackOnNearestCard()
        {
            var stackableCandidates = Physics2D.OverlapCircleAll(transform.position, stackDetectionRadius);
            foreach (var stackableCandidate in stackableCandidates)
            {
                if (!CanStackOn(stackableCandidate.gameObject))
                    continue;
                
                stackableCandidate.GetComponent<Stackable>().StackOnMe(GetComponent<Stackable>());
            }
        }

        bool CanStackOn(GameObject otherCard)
        {
            if (otherCard.GetComponent<Stackable>().HasSomethingStacked)
                return false;
            
            if (otherCard == gameObject)
                return false;

            if(!otherCard.GetComponent<Card>().IsStackableOnMe(GetComponent<Card>()))
                return false;

            return true;
        }

        public void OnMouseDrag()
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, stackDetectionRadius);
        }
    }
}