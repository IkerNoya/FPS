using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    public GameObject manager;
    public Text finalScore;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        manager = GameObject.Find("Manager");
    }

    void Update()
    {
        finalScore.text = "Score: " + manager.GetComponent<GameManager>().score.ToString();
    }
    public void OnClickMenu()
    {
        SceneManager.LoadScene("fps-menu");
    }
    public void OnClickGame()
    {
        manager.GetComponent<GameManager>().StartGame();
    }
    public void OnClickCredits()
    {
        SceneManager.LoadScene("fps-credits");
    }
}
