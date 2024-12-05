using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainUIController : MonoBehaviour
{
    public void gameStart()
    {
        SceneManager.LoadScene("level1");
    }

    public void gameExit()
    {
        Application.Quit();
    }

    public void tutorial()
    {
        SceneManager.LoadScene("howToPlay");
    }
}
