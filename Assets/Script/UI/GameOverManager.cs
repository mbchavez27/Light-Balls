using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Text highScoreText;
    public GameObject GameOverMenu;
    public bool gameOver = false;

    private void Start()
    {
        gameOver = false;
        Time.timeScale = 1f;
    }

    private void Update()
    {
        highScoreText.text = "Highscore:" + PlayerPrefs.GetInt("HighScore");

        if (Time.timeScale == 0f && this.GetComponent<GameOverManager>().gameOver)
        {
            GameOverMenu.SetActive(true);
        }
        else if (Time.timeScale == 1f && !this.GetComponent<GameOverManager>().gameOver)
        {
            GameOverMenu.SetActive(false);
        }
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
