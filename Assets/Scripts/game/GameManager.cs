using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    float timer;
    float sceneTimer;
    float survivalTimer;
    public float timerLimit;
    public float survivalTimeLimit = 10;
    int index;
    bool create = true;

    public GameObject enemy;
    public Transform player;
    public List<GameObject> spawns = new List<GameObject>();
    Transform currentSpawns;
    public GameManager gmanager;


    Vector3 initPlayerPos;

    private void Awake()
    {
        if (gmanager!=null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else if (gmanager!=this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {

        initPlayerPos = player.position;
    }
    void Update()
    {
        timer += Time.deltaTime;
        survivalTimer += Time.deltaTime;
        Debug.Log(survivalTimer);
        if (timer>=timerLimit && create == true)
        {
            CreateEnemy();
            timer = 0;
        }
        if (survivalTimer>=survivalTimeLimit)
        {
            create = false;
            sceneTimer += Time.deltaTime;
            if (sceneTimer>=timerLimit)
            {
                Restart();
                Cursor.lockState = CursorLockMode.None;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
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
