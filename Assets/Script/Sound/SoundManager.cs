using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip shoot, hit,changecolor;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(PlayerPrefs.GetString("sound") == "on")
        {
            audioSource.enabled = true;
        }
        if(PlayerPrefs.GetString("sound") == "off")
        {
            audioSource.enabled = false;
        }
    }

    public void ShootSound()
    {
        if(PlayerPrefs.GetString("sound") == "on")
            audioSource.PlayOneShot(shoot);
    }

    public void HitSound()
    {
        if (PlayerPrefs.GetString("sound") == "on")
            audioSource.PlayOneShot(hit);
    }

    public void ChangeColorSound()
    {
        if (PlayerPrefs.GetString("sound") == "on")
            audioSource.PlayOneShot(changecolor);
    }
}
