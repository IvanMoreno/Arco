using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

internal class Enemy : MonoBehaviour
{
    [SerializeField] GameObject attackPrediction;
    [SerializeField] GameObject movementPrediction;

    Color ActionColor => willAttackInThisTurn ? Color.red : Color.yellow;

    #region Algo que todavía no tenemos claro pero que se repite en character

    bool willAttackInThisTurn;
    public Task HacerLoQueTengaPendiente()
    {
        return GetComponent<AlgoComunEntreCharacterYEnemy>().HacerLoQueTengaPendiente();
    }
    
    public void ProgramarMovimiento(Vector3 target)
    {
        GetComponent<AlgoComunEntreCharacterYEnemy>().ProgramarMovimiento(target);
        willAttackInThisTurn = false;
    }
    
    public void ProgramarDisparo(Vector3 target)
    {
        willAttackInThisTurn = true;
        GetComponent<AlgoComunEntreCharacterYEnemy>().ProgramarDisparo(target);
    }

    public void RecibirImpacto()
    {
        GetComponent<AlgoComunEntreCharacterYEnemy>().RecibirImpacto();
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
            ? GetComponent<Disparo>().Target
            : GetComponent<Movimiento>().Destination;
    }

    void OnMouseExit()
    {
        GetComponentInChildren<LineRenderer>().SetPositions(Array.Empty<Vector3>());
        GetComponentInChildren<LineRenderer>().enabled = false;
    }
}