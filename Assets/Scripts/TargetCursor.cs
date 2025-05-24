using System.Threading.Tasks;
using UnityEngine;

internal class TargetCursor : MonoBehaviour
{
    public Task SelectTarget()
    {
        FindAnyObjectByType<Character>().GetComponent<Movimiento>().Hacia(transform.position + Vector3.right * 5f);
        return Task.CompletedTask;
    }
}