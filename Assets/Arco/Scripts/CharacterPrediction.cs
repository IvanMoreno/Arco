using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

internal class CharacterPrediction : MonoBehaviour
{
    public void LinkTowards(Vector3 destination)
    {
        LineRenderer().enabled = true;
        LineRenderer().SetPositions(new List<Vector3>()
        {
            transform.position,
            destination
        }.ToArray());
    }

    public async Task Hide()
    {
        LineRenderer().enabled = false;
        LineRenderer().SetPositions(Array.Empty<Vector3>());
    }

    public void DyePrediction(Color colorOf)
    {
        LineRenderer().startColor = colorOf;
        LineRenderer().endColor = colorOf;
    }

    LineRenderer LineRenderer() => GetComponent<LineRenderer>();
}