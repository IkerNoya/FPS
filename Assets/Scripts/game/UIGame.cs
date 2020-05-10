using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGame : MonoBehaviour
{
    public Player player;
    public Text playerHP;
    public Text score;
    void Start()
    {
        playerHP.color = Color.cyan;
        score.color = Color.cyan;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "SCORE: " + GameManager.Get().score.ToString();
        playerHP.text = "HP: " + player.hp.ToString();
    }
}
