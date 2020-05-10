using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    float sceneTimer;
    float survivalTimer;
    public float timerLimit;
    public float survivalTimeLimit = 10;
    public bool changeScene = false;
    public bool isInGame = false;

    public GameObject Player;
    public GameManager instance = null;



    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else if (instance!=this)
        {
            Destroy(gameObject);
        }

    }
    void Update()
    {
        Debug.Log(isInGame);
        if (isInGame)
        {
            survivalTimer += Time.deltaTime;
            //Debug.Log(survivalTimer);
            if (survivalTimer >= survivalTimeLimit)
            {
                sceneTimer += Time.deltaTime;
                changeScene = true;
                if (sceneTimer > timerLimit && changeScene == true)
                {

                    isInGame = false;
                    SceneManager.LoadScene("fps-end");
                    sceneTimer = 0;
                    survivalTimer = 0;
                    changeScene = false;

                }
            }
        }

    }
    public void StartGame()
    {
        SceneManager.LoadScene("fps-game");
        isInGame = true;
        score = 0;
    }

}
