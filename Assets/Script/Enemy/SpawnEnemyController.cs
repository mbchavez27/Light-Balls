using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyController : MonoBehaviour
{
    //Spawn Position
    public Transform spawnpointone, spawnpointtwo;
    public Transform spawnpoint;
    float spawnx;
    public GameObject enemy;
    //Spawn Rate
    public float spawnRate, spawnDelay;

    private void Start()
    {
        spawnDelay = Random.Range(2f, 3.5f);
    }

    void Update()
    {
        spawnRate += 1 * Time.deltaTime;
        if (spawnRate >= spawnDelay)
        {
            spawnDelay = Random.Range(2, 3.5f);
            spawnRate = 0f;
            Spawn();
        }
    }

    void Spawn()
    {
        spawnx = Random.Range(spawnpointone.position.x, spawnpointtwo.position.x);
        spawnpoint.position = new Vector3(spawnx, spawnpoint.position.y, spawnpoint.position.z);
        Instantiate(enemy, spawnpoint.position, spawnpoint.rotation);
    }
}
