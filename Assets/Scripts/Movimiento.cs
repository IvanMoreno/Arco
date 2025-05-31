using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;

internal class Movimiento : MonoBehaviour
{
    Vector3 destination;

    TaskCompletionSource<bool> tcs;

    public void Towards(Vector2 dónde)
    {
        Assert.IsNull(tcs, "Ya hay una tarea pendiente de movimiento");
        destination = dónde;
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
        
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * 5f);
        if (Vector3.Distance(transform.position, destination) < 0.1f)
            tcs.SetResult(true);
    }
}