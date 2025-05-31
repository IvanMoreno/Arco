using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

internal class MovementPrediction : MonoBehaviour
{
    public void LinkTowards(Vector3 destination)
    {
        GetComponent<LineRenderer>().enabled = true;
        GetComponent<LineRenderer>().SetPositions(new List<Vector3>()
        {
            transform.position,
            destination
        }.ToArray());
    }

    public async Task Hide()
    {
        GetComponent<LineRenderer>().enabled = false;
        GetComponent<LineRenderer>().SetPositions(Array.Empty<Vector3>());
    }
}