using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    /*
    private Rigidbody rb;
    private const int _carPoints = 10;
    private const int _multiplier = 3;
    //private GameManager _gameScore;

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
    }*/
    /*
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
        //_gameScore = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = velocity[spawnPoint] * 30;
        rb.AddTorque(new Vector3(2, 1, 4), ForceMode.Impulse);
        transform.position = spawn[spawnPoint];
    }

    // Update is called once per frame
    void Update()
    {

    }*/
}
