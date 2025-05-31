using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

internal class Enemy : MonoBehaviour
{
    [SerializeField] GameObject attackPrediction;
    [SerializeField] GameObject movementPrediction;

    Color ActionColor => GetComponent<Somebody>().WillAttack ? Color.red : Color.yellow;

    public async Task ShowPrediction()
    {
        attackPrediction.SetActive(GetComponent<Somebody>().WillAttack);
        movementPrediction.SetActive(!GetComponent<Somebody>().WillAttack);
    }

    public async Task HidePrediction()
    {
        attackPrediction.SetActive(false);
        movementPrediction.SetActive(false);
    }

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