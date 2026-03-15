using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float spawnTime = 1.0f;
    public int count = 0;
    public List<GameObject> cars;
    IEnumerator Spawner()
    {
        //for(int i = 0; i < 50; i++)
        while(true)
        {
            int chooser = Random.Range(0, cars.Count);
            yield return new WaitForSeconds(spawnTime);
            Instantiate(cars[chooser]);
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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
}
