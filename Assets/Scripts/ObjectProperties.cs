using UnityEngine;

public class ObjectProperties : MonoBehaviour
{
    
    [SerializeField]private int _points = 0;
    public int Points => _points;
}
