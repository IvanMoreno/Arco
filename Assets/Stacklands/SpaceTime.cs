using System;
using UnityEngine;

namespace Stacklands
{
    public class SpaceTime : MonoBehaviour
    {
        //aquí van a ir las cosas también del tiempo que ahora mismo están en la luna. :)

        public Stackable ClosestToBeStackedOn(Card card)
        {
            throw new NotImplementedException();
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