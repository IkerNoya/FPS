using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    public GameObject manager;
    private void Start()
    {
        manager = GameObject.Find("Manager");
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
