using System.Threading.Tasks;
using UnityEngine;

internal class TargetCursor : MonoBehaviour
{
    public async Task SelectTarget()
    {
        while (!Input.GetMouseButtonDown(0))
        {
            await Task.Yield();
        }
        
        FindAnyObjectByType<Character>().GetComponent<Movimiento>().Hacia(transform.position + Vector3.right * 5f);
    }
}