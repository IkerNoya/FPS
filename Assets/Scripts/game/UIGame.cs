using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGame : MonoBehaviour
{
    public Player player;
    GameObject manager;
    public Text playerHP;
    public Text score;
    void Start()
    {
        manager = GameObject.Find("Manager");
        playerHP.color = Color.cyan;
        score.color = Color.cyan;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "SCORE: " + manager.GetComponent<GameManager>().score.ToString();
        playerHP.text = "HP: " + player.hp.ToString();
    }
}
