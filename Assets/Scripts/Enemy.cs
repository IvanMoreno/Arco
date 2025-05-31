using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

internal class Enemy : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;

    [Header("Predictions")] 
    [SerializeField] GameObject attackPrediction;
    [SerializeField] GameObject movementPrediction;

    bool willAttackInThisTurn;
    Vector2 targetPosition;
    Color ActionColor => willAttackInThisTurn ? Color.red : Color.yellow;

    public Task HacerLoQueTengaPendiente()
    {
        return willAttackInThisTurn ? DispararHaciaElPersonaje() : Moverse();
    }

    async Task DispararHaciaElPersonaje()
    {
        var posPersonaje = FindAnyObjectByType<Character>().transform.position;

        //instantiate a projectile and move it towards the character
        var projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().Towards(posPersonaje);
    }

    Task Moverse()
    {
        GetComponent<Movimiento>().Towards(targetPosition);
        return GetComponent<Movimiento>().Hacerse();
    }

    public async Task DecidirSiguienteAccion()
    {
        willAttackInThisTurn = Random.value >= 0.5f;
        targetPosition = (Vector2)transform.position + Random.insideUnitCircle * 3;
    }

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
            targetPosition
        }.ToArray());
    }

    void OnMouseExit()
    {
        GetComponentInChildren<LineRenderer>().SetPositions(Array.Empty<Vector3>());
        GetComponentInChildren<LineRenderer>().enabled = false;
    }

    public void RecibirImpacto()
    {
        GetComponent<Vida>().UnaMenos();
        if (GetComponent<Vida>().EstaMuerto())
            Destroy(gameObject);
    }
}