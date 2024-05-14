using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed = 30f;
    public colour enemyColor;
    int randomcolor;
    public int[] maxcolor = new int[2];
    SpriteRenderer spriteRenderer;

    public float hitDamage = .2f;
    public GameObject explosionParticles;
    public float gameScore;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeColor();
        gameScore = GameObject.FindGameObjectWithTag("GameSystem").GetComponent<scoreManager>().score;
    }

    void Update()
    {
        //Move
        transform.position += -transform.up * enemySpeed * Time.deltaTime;

        //Change Speed
        ChangeSpeed();
    }
    
    void ChangeSpeed()
    {
        if(gameScore < 20)
        {
            enemySpeed = 1f;
        }
        if (gameScore > 20)
        {
            enemySpeed = 2f;
        }
        if (gameScore > 40)
        {
            enemySpeed = 2.5f;
        }
        if (gameScore > 60)
        {
            enemySpeed = 3f;
        }
        if (gameScore > 80)
        {
            enemySpeed = 3.5f;
        }
        if (gameScore > 100)
        {
            enemySpeed = 4f;
        }

    }

    void ChangeColor()
    {
        randomcolor = Random.Range(maxcolor[0], maxcolor[1]);

        if (randomcolor == 0)
        {
            enemyColor = colour.blue;
            spriteRenderer.color = new Color(0.07843135f, 0.6705883f, 0.643809f);
        }
        if (randomcolor == 1)
        {
            enemyColor = colour.red;
            spriteRenderer.color = new Color(0.6705883f, 0.09656926f, 0.07843135f);
        }
        if (randomcolor == 2)
        {
            enemyColor = colour.green;
            spriteRenderer.color = new Color(0.07843135f, 0.6705883f, 0.07843135f);
        }
        if (randomcolor == 3)
        {
            enemyColor = colour.yellow;
            spriteRenderer.color = new Color(0.6705883f, 0.6705883f, 0.07843135f);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            GameObject explosion = Instantiate(explosionParticles, this.transform.position, this.transform.rotation);
            explosion.gameObject.GetComponent<ParticleSystem>().startColor = this.GetComponent<SpriteRenderer>().color;
            GameObject.FindGameObjectWithTag("GameSystem").GetComponent<SoundManager>().HitSound();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().health -= hitDamage;
            Destroy(this.gameObject);
        }
        if(col.tag == "playerBase")
        {
            GameObject explosion = Instantiate(explosionParticles, this.transform.position, this.transform.rotation);
            explosion.gameObject.GetComponent<ParticleSystem>().startColor = this.GetComponent<SpriteRenderer>().color;
            GameObject.FindGameObjectWithTag("GameSystem").GetComponent<SoundManager>().HitSound();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().health -= hitDamage;
            Destroy(this.gameObject);
        }
    }
}
