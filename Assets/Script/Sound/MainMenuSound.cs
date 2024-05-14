using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenuSound : MonoBehaviour
{
    public Text soundText;
    string sound;

    private void Update()
    {
        Debug.Log(PlayerPrefs.GetString("sound", sound));
        if (PlayerPrefs.GetString("sound", sound) == "on")
        {
            soundText.text = "Sound On";
        }
        if (PlayerPrefs.GetString("sound", sound) == "off")
        {
            soundText.text = "Sound Off";
        }
        if (PlayerPrefs.GetString("sound", sound) == null)
        {
            soundText.text = "Sound On";
        }
    }


    public void SoundSettings()
    {
        if (PlayerPrefs.GetString("sound", sound) == "on" || PlayerPrefs.GetString("sound", sound) == null)
        {
            sound = "off";
            PlayerPrefs.SetString("sound", sound);
        }
        else
        {
            sound = "on";
            PlayerPrefs.SetString("sound", sound);
        }
    }
}
