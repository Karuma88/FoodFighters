using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ganaste1 : MonoBehaviour
{
    public void AGame()
    {
        //load gameplay scene
        SceneManager.LoadScene("Game");
    }

    public void Menu()
    {
        //load gameplay scene
        SceneManager.LoadScene("SampleScene");
    }

    public void SalirGame()
    {
        Application.Quit();
        Debug.Log("Salir");
    }
}
