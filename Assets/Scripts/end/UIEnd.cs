using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIEnd : MonoBehaviour
{
    public Text finalScore;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    void Update()
    {
        finalScore.text = "Score: " + GameManager.Get().score.ToString();
    }
    public void OnClickMenu()
    {
        SceneManager.LoadScene("fps-menu");
    }
    public void OnClickGame()
    {
        GameManager.Get().StartGame();
    }
    public void OnClickCredits()
    {
        SceneManager.LoadScene("fps-credits");
    }
}
