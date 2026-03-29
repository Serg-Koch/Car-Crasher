using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private Vector3[] _spawn = SpawnPoints.spawn;
    private Vector3[] _velocity = SpawnPoints.velocity;
    [SerializeField] private int _force = 30;
    [SerializeField] private Vector3 _torque = new(2, 1, 4);

    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int spawnPoint = Random.Range(0,_spawn.Length);
        transform.position = _spawn[spawnPoint];
        rb = GetComponent<Rigidbody>();
        rb.AddForce(_velocity[spawnPoint] * _force, ForceMode.Impulse);
        rb.AddTorque(new Vector3(2, 1, 4), ForceMode.Impulse);
    }
}
