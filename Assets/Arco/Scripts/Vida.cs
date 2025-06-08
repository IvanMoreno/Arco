using UnityEngine;

internal class Vida : MonoBehaviour
{
    [SerializeField] int puntos = 3;

    public void UnaMenos()
    {
        puntos--;
    }
    
    public bool EstaMuerto()
    {
        return puntos <= 0;
    }
}