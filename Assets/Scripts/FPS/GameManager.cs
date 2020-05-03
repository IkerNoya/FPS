using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int score = 0;
    public int scoreLimit = 1000;
    float timer;
    public float timerLimit;
    int index;
    public GameObject enemy;
    public Transform player;
    public List<GameObject> spawns = new List<GameObject>();
    Transform currentSpawns;
    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer>=timerLimit)
        {
            CreateEnemy();
            timer = 0;
        }
        Debug.Log(timer);
    }
    
    void CreateEnemy()
    {
        index = Random.Range(0, spawns.Count);
        currentSpawns = spawns[index].transform;
        enemy.GetComponent<Enemy>().player = player;
        Instantiate(enemy, currentSpawns);
    }
}
