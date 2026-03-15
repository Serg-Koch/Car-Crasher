using System.Collections.Generic;
using UnityEngine;

public class PartsBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    private const int _carPoints = 10;
    private const int _multiplier = 3;
    private GameManager _gameScore;
    static List <Vector3> velocity = new()
    {
        new Vector3(-1, 1, 0),
        new Vector3(-1, 0, 0),
        new Vector3(1, 1, 0),
        new Vector3(1, 0, 0)
    };

    static List <Vector3> spawn = new()
    {
        new Vector3(47, 0, -3.0f),
        new Vector3(47, 15, -3.0f),
        new Vector3(-47, 0, -3.0f),
        new Vector3(-47, 15, -3.0f)
    };
    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Floor":
                FloorDestroy();
                break;
            case "BadPart":
                ParentDestroy(0);
                break;
            case "GoodPart":
                if (gameObject.tag != "Bad")
                    ParentDestroy(_carPoints * _multiplier);
                break;
            default:
                break;
        }
    }
    void OnMouseDown()
    {
        if (gameObject.tag != "Bad")
        {
            ParentDestroy(_carPoints);
        }
        else
        {
            ParentDestroy(_carPoints * -5);
        }
    }
    private void ParentDestroy(int points)
    {
        gameObject.transform.DetachChildren();
        if (_gameScore.count + points < 0)
        {
            _gameScore.count = 0;
        }
        else
        {
            _gameScore.count += points;
        }
        Destroy(gameObject);
    }
    private void FloorDestroy()
    {
        foreach (Transform child in transform)
        {
                child.gameObject.tag = "Inactive";
        }
        gameObject.transform.DetachChildren();
        Destroy(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int spawnPoint = Random.Range(0,spawn.Count);
        _gameScore = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        /*if(spawnPoint % 2 == 1)
        {
            rb.linearVelocity = velocity[spawnPoint] * 50;
        }
        else
        {
            rb.linearVelocity = velocity[spawnPoint] * 30;
        }*/
        rb.linearVelocity = velocity[spawnPoint] * 30;
        rb.AddTorque(new Vector3(2, 1, 4), ForceMode.Impulse);
        transform.position = spawn[spawnPoint];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
