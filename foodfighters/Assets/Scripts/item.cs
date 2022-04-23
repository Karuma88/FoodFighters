using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class item : MonoBehaviour
{
    //variables
    public static int countCoins = 0;
    public TextMeshProUGUI textScore;
    public static int scoreCoins;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Moneda creada");
        item.countCoins++;
        textScore.text = "26";
    }

    // Update is called once per frame
    void Update()
    {
        scoreCoins = countCoins - 1;
    }

    void OnDestroy()
    {
        item.countCoins--;

        if (item.countCoins <= 0)
        {
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Item Recolectado");
        if (collider.CompareTag("Player"))
        {
            Destroy(gameObject);
            textScore.text = item.scoreCoins.ToString();
        }
    }
}
