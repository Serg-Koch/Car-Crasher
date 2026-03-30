using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    //public Button start;
    public TextMeshProUGUI scoreText;
    
    public void ShowScore(int score)
    {
        scoreText.text = $"Score: {score}";
    }
    
    void OnEnable()
    {
        ScoreManager.ScoreChange += ShowScore;
    }

}
