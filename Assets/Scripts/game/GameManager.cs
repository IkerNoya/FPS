using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int scoreLimit = 1000;
    float timer;
    float sceneTimer;
    public float timerLimit;
    int index;
    bool create = true;

    public GameObject enemy;
    public Transform player;
    public List<GameObject> spawns = new List<GameObject>();
    Transform currentSpawns;

    Vector3 initPlayerPos;

    private void Start()
    {
        initPlayerPos = player.position;
        DontDestroyOnLoad(this);
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>=timerLimit && create == true)
        {
            CreateEnemy();
            timer = 0;
        }
        if (score>=scoreLimit)
        {
            create = false;
            sceneTimer += Time.deltaTime;
            if (sceneTimer>=timerLimit)
            {
                Restart();
                SceneManager.LoadScene("fps-end");
            }
        }

    }
    private void Restart()
    {
        score = 0;
        index = 0;
        player.position = initPlayerPos;
        timer = 0;
        sceneTimer = 0;
        create = true;
    }

    void CreateEnemy()
    {
        index = Random.Range(0, spawns.Count);
        currentSpawns = spawns[index].transform;
        enemy.GetComponent<Enemy>().player = player;
        Instantiate(enemy, currentSpawns);
    }
}
