using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInicio : MonoBehaviour
{
    public GameObject Image;
    public void CloseImage()
    {
        if(Image != null)
        {
            Image.SetActive(false);
        }
    }

}
