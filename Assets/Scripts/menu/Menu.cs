using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameManager manager;
    public void OnClickGame()
    {
        manager.StartGame();
    }
    public void OnClickCredits()
    {
        SceneManager.LoadScene("fps-credits");
    }
}
