using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Perdiste : MonoBehaviour
{
    public void RestartGame()
    {
        //load gameplay scene
        SceneManager.LoadScene("Game");
    }

    public void MenuP()
    {
        //load gameplay scene
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Salir");
    }
}
