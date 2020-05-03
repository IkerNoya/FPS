using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    public GameManager manager;
    public Text finalScore;

    void Update()
    {
        finalScore.text = "Score: " + manager.score.ToString();
    }
    public void OnClickMenu()
    {
        SceneManager.LoadScene("fps-menu");
    }
    public void OnClickGame()
    {
        SceneManager.LoadScene("fps-game");
    }
    public void OnClickCredits()
    {
        SceneManager.LoadScene("fps-credits");
    }
}
