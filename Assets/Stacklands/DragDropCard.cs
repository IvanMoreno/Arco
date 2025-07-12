using UnityEngine;

namespace Stacklands
{
    public class DragDropCard : MonoBehaviour
    {
        bool isDragging;
        Card onTopOf;

        public void OnMouseDown()
        {
            isDragging = true;
            GetComponent<Stackable>().RemoveFromStack();
        }

        public void OnMouseUp()
        {
            isDragging = false;

            if (onTopOf != null) 
                StackOnCard();
        }

        void StackOnCard() => GetComponent<Stackable>().StackOver(onTopOf.GetComponent<Stackable>());

        public void OnMouseDrag()
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent<Card>(out var card))
                return;

            onTopOf = card;
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (!other.TryGetComponent<Card>(out var card) || card != onTopOf)
                return;

            onTopOf = null;
        }
    }
}