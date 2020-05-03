using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnClickGame()
    {
        SceneManager.LoadScene("fps-game");
    }
    public void OnClickCredits()
    {
        SceneManager.LoadScene("fps-credits");
    }
}
