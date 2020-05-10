using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float timer;
    public float timerLimit;
    bool create = true;
    int index;

    public List<GameObject> spawns = new List<GameObject>();
    Transform currentSpawns;

    public GameObject enemy;
    public Transform player;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timerLimit && create == true)
        {
            CreateEnemy();
            timer = 0;
        }
    }
void CreateEnemy()
    {
        index = Random.Range(0, spawns.Count);
        currentSpawns = spawns[index].transform;
        enemy.GetComponent<Ghost>().player = player;
        Instantiate(enemy, currentSpawns);
    }
}
