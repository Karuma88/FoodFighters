using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    //public Animator ani;
    public Quaternion angulo;
    public float grado;

    public GameObject target;

    public bool atacando;

    // Start is called before the first frame update
    void Start()
    {
        //ani = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Comportamiento_Enemigo();
        Final_Ani();

    }

    void Update()
    {
        if (transform.position.y < -8.0f)
        {
            Destroy(gameObject);
            Destroy(this);
            Destroy(GetComponent<Rigidbody>());

        }
    }

    public void Comportamiento_Enemigo()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 5)
        {
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }

            switch (rutina)
            {
                case 0:
                    //ani.SetBool("walk", false);
                    break;

                case 1:
                    grado = Random.Range(0, 260);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;

                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(1 * Time.deltaTime * Vector3.forward);
                    //ani.SetBool("walk", true);
                    break;
            }
        }
        else if (Vector3.Distance(transform.position, target.transform.position) > 1 && !atacando)
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
            //ani.SetBool("walk",false);

            //ani.SetBool("run",true);
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);

            //ani.SetBool("attack",false);
        }
        else
        {
            //ani.SetBool("walk",false);
            //ani.SetBool("run",false);
            //ani.SetBool("attack",true);
            atacando = true;
        }
    }



    public void Final_Ani()
    {
        //ani.SetBool("attack", false);
        atacando = false;
    }
}