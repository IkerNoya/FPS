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
        if (SceneManager.GetActiveScene()==SceneManager.GetSceneByName("fps-game"))
        {
            survivalTimer += Time.deltaTime;
            if (survivalTimer >= survivalTimeLimit)
            {
                sceneTimer += Time.deltaTime;
                changeScene = true;
                if (sceneTimer > timerLimit && changeScene == true)
                {

                   SceneManager.LoadScene("fps-end");
                    sceneTimer = 0;
                    survivalTimer = 0;
                    changeScene = false;

                }
            }
        }

    }

}
