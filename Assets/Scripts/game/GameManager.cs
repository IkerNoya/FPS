﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    float sceneTimer;
    public float timerLimit;
    public bool changeScene = false;
    public bool isInGame = false;
    public int winCounter;
    int winLimit = 13;

    public GameObject player;
    private static GameManager instance = null;

    public static GameManager Get()
    {
        return instance;
    }

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
        if (isInGame)
        {
            if (winCounter>=winLimit)
            {
                sceneTimer += Time.deltaTime;
                changeScene = true;
                if (sceneTimer > timerLimit && changeScene == true)
                { 
                    isInGame = false;
                    SceneManager.LoadScene("fps-end");
                    sceneTimer = 0;
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
        winCounter = 0;
    }

}
