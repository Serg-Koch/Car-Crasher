using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    private float spawnTime = 1.0f;
    public int count = 0;
    public List<GameObject> cars;
    public Button button;
    public TextMeshProUGUI scoreText;
    IEnumerator Spawner()
    {
        for(int i = 0; i < 60; i++)
        {
            int chooser = Random.Range(0, cars.Count);
            yield return new WaitForSeconds(spawnTime);
            Instantiate(cars[chooser]);
        }
    }
    public void StartGame()
    {
        button.gameObject.SetActive(false);
        StartCoroutine(Spawner());
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        scoreText.text = $"Score: {count}";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"Score: {count}";
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } 
        
    }
}
