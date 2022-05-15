using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerTriggers : MonoBehaviour
{
    public Text enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] enemigos;
        enemigos = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount.text = "Enemigos restantes: " + enemigos.Length.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -8.0f)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Perdiste");
        }
    }
}
