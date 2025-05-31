using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

internal class Enemy : MonoBehaviour
{
    [SerializeField] GameObject attackPrediction;
    [SerializeField] GameObject movementPrediction;

    Vector2 targetPosition;
    Color ActionColor => willAttackInThisTurn ? Color.red : Color.yellow;

    #region Algo que todavía no tenemos claro pero que se repite en character

    bool willAttackInThisTurn;

    public Task HacerLoQueTengaPendiente()
    {
        return willAttackInThisTurn
            ? GetComponent<Disparo>().Hacerse()
            : GetComponent<Movimiento>().Hacerse();
    }
    
    public void ProgramarMovimiento(Vector3 target)
    {
        willAttackInThisTurn = false;
        targetPosition = target;
        GetComponent<Movimiento>().Towards(target);
    }
    
    public void ProgramarDisparo(Vector3 target)
    {
        willAttackInThisTurn = true;
        targetPosition = target;
        GetComponent<Disparo>().Towards(target);
    }

    public void RecibirImpacto()
    {
        GetComponent<Vida>().UnaMenos();
        if (GetComponent<Vida>().EstaMuerto())
            Destroy(gameObject);
    }

    #endregion

    public async Task ShowPrediction()
    {
        attackPrediction.SetActive(willAttackInThisTurn);
        movementPrediction.SetActive(!willAttackInThisTurn);
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
            TargetOfThePreview()
        }.ToArray());
    }

    Vector2 TargetOfThePreview()
    {
        return willAttackInThisTurn
            ? targetPosition
            : GetComponent<Movimiento>().Destination;
    }

    void OnMouseExit()
    {
        GetComponentInChildren<LineRenderer>().SetPositions(Array.Empty<Vector3>());
        GetComponentInChildren<LineRenderer>().enabled = false;
    }
}