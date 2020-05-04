using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{
    void Awake()
    {
        SceneManager.LoadScene("fps-menu");
    }

}
