using System;
using System.Collections.Generic;
using UnityEngine;

internal class PredictIntentOnHover : MonoBehaviour
{
    Color ActionColor => GetComponent<Somebody>().WillAttack ? Color.red : Color.yellow;
    
    void OnMouseEnter()
    {
        GetComponentInChildren<LineRenderer>().enabled = true;
        GetComponentInChildren<LineRenderer>().startColor = ActionColor;
        GetComponentInChildren<LineRenderer>().endColor = ActionColor;
        GetComponentInChildren<LineRenderer>().SetPositions(new List<Vector3>()
        {
            transform.position,
            TargetOfThePrediction()
        }.ToArray());
    }

    Vector2 TargetOfThePrediction()
    {
        return GetComponent<Somebody>().WillAttack
            ? GetComponent<Disparo>().Target
            : GetComponent<Movimiento>().Destination;
    }

    void OnMouseExit()
    {
        GetComponentInChildren<LineRenderer>().SetPositions(Array.Empty<Vector3>());
        GetComponentInChildren<LineRenderer>().enabled = false;
    }
}