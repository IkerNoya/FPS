using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    public GameManager manager;
    public Text finalScore;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

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
        manager.StartGame();
    }
    public void OnClickCredits()
    {
        SceneManager.LoadScene("fps-credits");
    }
}
