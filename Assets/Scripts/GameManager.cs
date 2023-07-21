using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject spike;
    public GameObject fireball;
    public GameObject platform;
    public GameObject coin;
    public GameObject bonus;

    public GameObject[] spawnPoints;
    public float timer;
    public float timeBetweenSpawns;

    public float SpeedMultiplier;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeBetweenSpawns)
        {
            timer = 0;
            int randNum = Random.Range(0, 3);
            if (randNum == 0)
            {
                Instantiate(spike, spawnPoints[0].transform.position, Quaternion.identity);
            }
            if (randNum == 1)
            {
                Instantiate(platform, spawnPoints[1].transform.position, Quaternion.identity);
            }
            if (randNum == 2)
            {
                Instantiate(fireball, spawnPoints[2].transform.position, Quaternion.identity);
            }
            randNum = Random.Range(0, 6);
            if (randNum < 3)
            {
                Instantiate(coin, spawnPoints[randNum].transform.position, Quaternion.identity);

            }
            randNum = Random.Range(0, 10);
            if (randNum == 5)
            {
                Instantiate(bonus, spawnPoints[Random.Range(0,3)].transform.position, Quaternion.identity);
            }
        }
    }
}

