using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;

internal class Movimiento : MonoBehaviour, Intent
{
    public Vector3 Destination { get; private set; }

    TaskCompletionSource<bool> tcs;

    public void Towards(Vector2 dónde)
    {
        Assert.IsNull(tcs, "Ya hay una tarea pendiente de movimiento");
        Destination = dónde;
    }
    
    public async Task Hacerse()
    {
        tcs = new();
        await tcs.Task;
        tcs = null;
    }

    void Update()
    {
        if (tcs == null)
            return;
        
        transform.position = Vector3.MoveTowards(transform.position, Destination, Time.deltaTime * 5f);
        if (Vector3.Distance(transform.position, Destination) < 0.1f)
            tcs.SetResult(true);
    }

    void OnDestroy()
    {
        tcs?.TrySetResult(true);
    }
}