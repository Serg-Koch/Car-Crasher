using UnityEngine;
using System;
using UnityEngine.UI;

public class GameStateUI : MonoBehaviour
{
    //Button events
    /*public static event Action StartGameButtonClicked;
    public static event Action PauseGameButtonClicked;
    public static event Action RestartGameButtonClicked;*/
    
    //variables
    public Button startButton;
    public Button pauseButton;
    public Button restarttButton;

    private void RestartButtonActive()
    {
        pauseButton.gameObject.SetActive(false);
        restarttButton.gameObject.SetActive(true);

    }
    private void OnEnable() 
    {
        SpawnManager.RoundOver += RestartButtonActive;
    }
    private void OnDisable()
    {
        SpawnManager.RoundOver -= RestartButtonActive;    
    }
    //methods
    /*private void StartGame()
    {
        startButton.SetActive(false);
        StartGame?.Invoke();
    }
    private void PauseGame()
    {
        PauseGame?.Invoke();
    }
    private void RestartGame()
    {
        StartGame?.Invoke();
    }*/
}
