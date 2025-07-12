using System.Collections;
using System.Collections.Generic;

namespace Stacklands
{
    public class StackOfCards : IEnumerable<Stackable>
    {
        private readonly List<Stackable> cards;
        
        public StackOfCards(IEnumerable<Stackable> cards)
        {
            this.cards = new List<Stackable>(cards);
        }
        
        public static StackOfCards Empty()
        {
            return new StackOfCards(new List<Stackable>());
        }
        public IEnumerator<Stackable> GetEnumerator() => cards.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}