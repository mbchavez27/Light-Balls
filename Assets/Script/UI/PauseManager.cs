using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseButton,pauseMenu;

    private void Update()
    {
        if (Time.timeScale == 1f && !this.GetComponent<GameOverManager>().gameOver)
        {
            pauseMenu.SetActive(false);
            pauseButton.SetActive(true);
        }
        else if(Time.timeScale == 0f && !this.GetComponent<GameOverManager>().gameOver)
        {
            pauseMenu.SetActive(true);
            pauseButton.SetActive(false);
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void PlayGame()
    {
        Time.timeScale = 1f;
    }

    public void ResetGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
