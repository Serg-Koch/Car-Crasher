using System;
using UnityEngine;
public class GameStateManager : MonoBehaviour
{
    //public static event Action StartButton;
    public void ResumeGame()
    {
        Time.timeScale = 1;
        //StartCoroutine(Spawner());
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
    }
}
