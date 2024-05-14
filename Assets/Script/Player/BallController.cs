using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float ballSpeed = 30f;
    public colour ballColor;
    public GameObject explosionParticles;

    void Update()
    {
        //Move
        transform.position += transform.up * ballSpeed * Time.deltaTime;
        CheckColor();
    }

    void CheckColor()
    {
        //Check Color
        if (this.GetComponent<SpriteRenderer>().color == new Color(0.07843135f, 0.6705883f, 0.643809f))
        {
            ballColor = colour.blue;
        }
        if (this.GetComponent<SpriteRenderer>().color == new Color(0.6705883f, 0.09656926f, 0.07843135f))
        {
            ballColor = colour.red;
        }
        if (this.GetComponent<SpriteRenderer>().color == new Color(0.07843135f, 0.6705883f, 0.07843135f))
        {
            ballColor = colour.green;
        }
        if (this.GetComponent<SpriteRenderer>().color == new Color(0.6705883f, 0.6705883f, 0.07843135f))
        {
            ballColor = colour.yellow;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Walls")
        {
            GameObject explosion = Instantiate(explosionParticles, this.transform.position, this.transform.rotation);
            explosion.gameObject.GetComponent<ParticleSystem>().startColor = this.GetComponent<SpriteRenderer>().color;
            GameObject.FindGameObjectWithTag("GameSystem").GetComponent<SoundManager>().HitSound();
            Destroy(this.gameObject);
        }
        if(collision.tag == "Enemy")
        {
            if(ballColor == collision.gameObject.GetComponent<EnemyController>().enemyColor)
            {
                GameObject explosion = Instantiate(explosionParticles, this.transform.position, this.transform.rotation);
                explosion.gameObject.GetComponent<ParticleSystem>().startColor = this.GetComponent<SpriteRenderer>().color;
                Destroy(this.gameObject);
                Destroy(collision.gameObject);
                GameObject.FindGameObjectWithTag("GameSystem").GetComponent<SoundManager>().HitSound();
                GameObject.FindGameObjectWithTag("GameSystem").GetComponent<scoreManager>().score++;
            }
        }
    }
}
