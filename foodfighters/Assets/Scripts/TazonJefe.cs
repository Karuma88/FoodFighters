using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TazonJefe : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("Enemy");

        if (gameObjects.Length < 0)
        {
            Debug.Log("xddd");
        }
    }
}
