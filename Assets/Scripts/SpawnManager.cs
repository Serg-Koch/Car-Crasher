using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    public static event Action RoundOver;
    [SerializeField] private float bufferTime = 3.0f;
    [SerializeField] private float spawnTime = 1.0f;
    [SerializeField] private List<GameObject> cars;
    private int _destroyedCarsCount = 0;
    private int _carSpawnCount = 1;
    public void AddCarSpawnCount()
    {
        _carSpawnCount += 1;   
    }
    public void ZeroCarSpawnCount()
    {
        _carSpawnCount = 1;
    }
    private void AddDestroyedCarsCount()
    {
        _destroyedCarsCount += 1;
        if(_destroyedCarsCount == _carSpawnCount)
        {
            CarSpawnCountUpdate();
        }
    }
    private void CarSpawnCountUpdate()
    {
            AddCarSpawnCount();
            _destroyedCarsCount = 0;
    }
    private void ZeroDestroyedCarsCount()
    {
        _destroyedCarsCount = 0;
    }
    IEnumerator Spawner()
    {
        for(int i = 0; i < 20; i++)
        //while(true)
        {
            yield return new WaitForSeconds(bufferTime);
            for(int j = 0; j < _carSpawnCount; j++)
            {
                yield return new WaitForSeconds(spawnTime);
                int chooser = UnityEngine.Random.Range(0, cars.Count);
                Instantiate(cars[chooser]);
            }
        }
        RoundOver?.Invoke();
    }
    public void CarSpawn()
    {
        StartCoroutine(Spawner());
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     private void OnEnable() 
     {
        PlayerInput.LMBClickObject += AddDestroyedCarsCount;
        PlayerInput.LMBClickEmpty += ZeroDestroyedCarsCount;
        PlayerInput.LMBClickEmpty += ZeroCarSpawnCount;
     }
     private void OnDisable() 
     {
        PlayerInput.LMBClickObject -= AddDestroyedCarsCount;
        PlayerInput.LMBClickEmpty -= ZeroDestroyedCarsCount;
        PlayerInput.LMBClickEmpty += ZeroCarSpawnCount;   
     }
}
