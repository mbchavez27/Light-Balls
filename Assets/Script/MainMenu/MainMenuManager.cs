using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Animator anim;
    public Text HighScoreText;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        HighScoreText.text = "HighScore:" + PlayerPrefs.GetInt("HighScore");
    }

    public void PlayGame()
    {
        StartCoroutine(startPlayGame());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator startPlayGame()
    {
        anim.SetTrigger("transition");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainGame");
    }
}
