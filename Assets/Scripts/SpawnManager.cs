using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    
    [SerializeField] private float bufferTime = 3.0f;
    [SerializeField] private float spawnTime = 1.0f;
    [SerializeField] private List<GameObject> cars;
    
    IEnumerator Spawner()
    {
        for(int i = 0; i < 60; i++)
        {
            yield return new WaitForSeconds(bufferTime);
            for(int j = 0; j < 7; j++)
            {
                yield return new WaitForSeconds(spawnTime);
                int chooser = Random.Range(0, cars.Count);
                Instantiate(cars[chooser]);
            }
            
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
