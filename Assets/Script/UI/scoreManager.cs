using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public Text scoreText;
    public int score;

    private void Start()
    {
        PlayerPrefs.GetInt("HighScore", score);
    }
    private void Update()
    {
        scoreText.text = score.ToString();

        if (this.GetComponent<GameOverManager>().gameOver)
        {
            SetHighScore();
        }
    }

    void SetHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
