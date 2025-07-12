using UnityEngine;

namespace Stacklands
{
    public class DragDropCard : MonoBehaviour
    {
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
            FindFirstObjectByType<SpaceTime>()
                .ClosestToBeStackedOn(GetComponent<Card>())?
                .StackOnMe(GetComponent<Stackable>());
        }

        public void OnMouseDrag()
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }

        void OnDrawGizmosSelected()
        {
            var toBeStackedOn = FindFirstObjectByType<SpaceTime>().ClosestToBeStackedOn(GetComponent<Card>());
            if (toBeStackedOn == null) 
                return;
            
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, toBeStackedOn.transform.position);
            Gizmos.DrawWireSphere(toBeStackedOn.transform.position, 1);
        }
    }
}