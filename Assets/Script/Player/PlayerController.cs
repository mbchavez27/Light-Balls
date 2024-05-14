using System.Collections;
//using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum colour
{
    blue, red, yellow, green
};

public class PlayerController : MonoBehaviour
{
    //Change Color  
    [Header("Change Color")]
    public GameObject aim,plbase,healthbar;
    public colour playerColor;
    SpriteRenderer spriteRenderer;
    int randomcolor;
    public float opacity;
    public int[] maxcolor = new int[2];
    //Rotate
    [Header("Rotate")]
    public float rotateSpeed;
    //Shoot
    [Header("Shoot")]
    public Transform aimSpawn;
    public GameObject lightBalls;
    //Delay,Rate
    [Header("Delay,Rate")]
    public float shootrate, shootDelay = .3f,colorrate,colordelay = .5f;
    //Health
    public float health = 1f;

    private void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        RandomColor();
    }

    private void Update()
    {
        RotatePlayer();
        ClickMechanics();
        PlayerHealth();
    }

    void PlayerHealth()
    {
        healthbar.GetComponent<Image>().fillAmount = health;
        if(health <= 0)
        {
            GameObject.FindGameObjectWithTag("GameSystem").GetComponent<PauseManager>().PauseGame();
            GameObject.FindGameObjectWithTag("GameSystem").GetComponent<GameOverManager>().gameOver = true;
        }
    }

    void RotatePlayer()
    {
        //rotate
        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);

        //check if player needs to rotate back
        if (transform.rotation.eulerAngles.z >= 90)
        {
            rotateSpeed = -rotateSpeed;
        }
        if (transform.rotation.eulerAngles.z >= 270)
        {
            rotateSpeed = -rotateSpeed;
        }
    }

    void ClickMechanics()
    {
        if (Input.GetMouseButton(0) || Input.touchCount == 1)
        {
            Vector2 hitorigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hits = Physics2D.Raycast(hitorigin, Vector2.zero);

            //If hit player
            if (hits.collider != null)
            {
                if(hits.collider.tag == "Player")
                {
                    Shoot();
                }

                if(hits.collider.tag == "ChangeColor")
                {
                    colorrate += 1 * Time.deltaTime;
                    if (colorrate >= colordelay)
                    {
                        colorrate = 0f;
                        ChangeColor();
                    }
                }
                if (hits.collider.tag == "Rotate")
                {
                    RotatePlayer();
                }
            }
            else
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
       shootrate += 1 * Time.deltaTime;
        if (shootrate >= shootDelay)
        {
            shootrate = 0;
            GameObject.FindGameObjectWithTag("GameSystem").GetComponent<SoundManager>().ShootSound();
            GameObject ball = Instantiate(lightBalls, aimSpawn.position, aimSpawn.rotation);
            ball.GetComponent<SpriteRenderer>().color = this.spriteRenderer.color;
        }
    }

    void RandomColor()
    {
        randomcolor = Random.Range(maxcolor[0], maxcolor[1]);

        if (randomcolor == 0)
        {
            playerColor = colour.blue;
            spriteRenderer.color = new Color(0.07843135f, 0.6705883f, 0.643809f);
            aim.GetComponent<SpriteRenderer>().color = new Color(0.07843135f, 0.6705883f, 0.643809f);
            plbase.GetComponent<SpriteRenderer>().color = new Color(0.07843135f, 0.6705883f, 0.643809f,opacity);
            healthbar.GetComponent<Image>().color = new Color(0.07843135f, 0.6705883f, 0.643809f);
        }
        if (randomcolor == 1)
        {
            playerColor = colour.red;
            spriteRenderer.color = new Color(0.6705883f, 0.09656926f, 0.07843135f);
            aim.GetComponent<SpriteRenderer>().color = new Color(0.6705883f, 0.09656926f, 0.07843135f);
            plbase.GetComponent<SpriteRenderer>().color = new Color(0.6705883f, 0.09656926f, 0.07843135f, opacity);
            healthbar.GetComponent<Image>().color = new Color(0.6705883f, 0.09656926f, 0.07843135f);

        }
        if (randomcolor == 2)
        {
            playerColor = colour.green;
            spriteRenderer.color = new Color(0.07843135f, 0.6705883f, 0.07843135f);
            aim.GetComponent<SpriteRenderer>().color = new Color(0.07843135f, 0.6705883f, 0.07843135f);
            plbase.GetComponent<SpriteRenderer>().color = new Color(0.07843135f, 0.6705883f, 0.07843135f, opacity);
            healthbar.GetComponent<Image>().color = new Color(0.07843135f, 0.6705883f, 0.07843135f);
        }
        if (randomcolor == 3)
        {
            playerColor = colour.yellow;
            spriteRenderer.color = new Color(0.6705883f, 0.6705883f, 0.07843135f);
            aim.GetComponent<SpriteRenderer>().color = new Color(0.6705883f, 0.6705883f, 0.07843135f);
            plbase.GetComponent<SpriteRenderer>().color = new Color(0.6705883f, 0.6705883f, 0.07843135f, opacity);
            healthbar.GetComponent<Image>().color = new Color(0.6705883f, 0.6705883f, 0.07843135f);
        }
    }

    void ChangeColor()
    {
        randomcolor++;
        if (randomcolor == 0)
        {
            playerColor = colour.blue;
            spriteRenderer.color = new Color(0.07843135f, 0.6705883f, 0.643809f);
            aim.GetComponent<SpriteRenderer>().color = new Color(0.07843135f, 0.6705883f, 0.643809f);
            plbase.GetComponent<SpriteRenderer>().color = new Color(0.07843135f, 0.6705883f, 0.643809f, opacity);
            healthbar.GetComponent<Image>().color = new Color(0.07843135f, 0.6705883f, 0.643809f);
        }
        if (randomcolor == 1)
        {
            playerColor = colour.red;
            spriteRenderer.color = new Color(0.6705883f, 0.09656926f, 0.07843135f);
            aim.GetComponent<SpriteRenderer>().color = new Color(0.6705883f, 0.09656926f, 0.07843135f);
            plbase.GetComponent<SpriteRenderer>().color = new Color(0.6705883f, 0.09656926f, 0.07843135f, opacity);
            healthbar.GetComponent<Image>().color = new Color(0.6705883f, 0.09656926f, 0.07843135f);

        }
        if (randomcolor == 2)
        {
            playerColor = colour.green;
            spriteRenderer.color = new Color(0.07843135f, 0.6705883f, 0.07843135f);
            aim.GetComponent<SpriteRenderer>().color = new Color(0.07843135f, 0.6705883f, 0.07843135f);
            plbase.GetComponent<SpriteRenderer>().color = new Color(0.07843135f, 0.6705883f, 0.07843135f, opacity);
            healthbar.GetComponent<Image>().color = new Color(0.07843135f, 0.6705883f, 0.07843135f);
        }
        if (randomcolor == 3)
        {
            playerColor = colour.yellow;
            spriteRenderer.color = new Color(0.6705883f, 0.6705883f, 0.07843135f);
            aim.GetComponent<SpriteRenderer>().color = new Color(0.6705883f, 0.6705883f, 0.07843135f);
            plbase.GetComponent<SpriteRenderer>().color = new Color(0.6705883f, 0.6705883f, 0.07843135f, opacity);
            healthbar.GetComponent<Image>().color = new Color(0.6705883f, 0.6705883f, 0.07843135f);
        }
        if(randomcolor >= 4)
        {
            randomcolor = -1;
        }
        GameObject.FindGameObjectWithTag("GameSystem").GetComponent<SoundManager>().ShootSound();
    }
}
