using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public Rigidbody playerCharacter;
    public float speed;
    public float boostTimer;
    private bool boosting;
    public Slider BoostBar;

    private Vector3 _inputs = Vector3.zero;

    public float rotSpeed = 360f;

   
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        playerCharacter = GetComponent<Rigidbody>();
        boostTimer = 0f;
        boosting = false;

    }

    // Update is called once per frame
    void Update()
    {
        BoostBar.value = 0.5f / boostTimer;
        if (BoostBar.value >= 1.0f)
        {
            BoostBar.gameObject.SetActive(false);
        }
        else
        {
            BoostBar.gameObject.SetActive(true);
        }
        if (boosting)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer >= 3f)
            {
                speed = 5f;
                boostTimer = 0f;
                boosting = false;
                
            }
        }
    }

    void FixedUpdate()
    {
        _inputs = Vector3.zero;
        _inputs.x = Input.GetAxisRaw("Horizontal");
        _inputs.z = Input.GetAxisRaw("Vertical");

        if (_inputs.x != 0.0f || _inputs.z != 0.0f)
        {
            Vector3 moveDir = (transform.forward * _inputs.z + transform.right * _inputs.x).normalized;
            //playerCharacter.MovePosition(transform.position + direction * speed * Time.deltaTime);
            //Vector3 moveDir = new Vector3(_inputs.x, 0, _inputs.z);

            playerCharacter.MovePosition(transform.position + moveDir * speed * Time.fixedDeltaTime);
            //transform.forward = moveDir;


            //eincode Move and rotate the object in direction of movement! Unity basics.
            Quaternion rotatePlayer = Quaternion.LookRotation(moveDir);

            rotatePlayer = Quaternion.RotateTowards(transform.rotation, rotatePlayer, rotSpeed * Time.fixedDeltaTime);

            playerCharacter.MoveRotation(rotatePlayer);
           

            if (Input.GetKey("s") == true)
            {
                rotSpeed = 0f;
                //Debug.Log("rotSpeed" + rotSpeed);
                return;

            }

            rotSpeed = 360f;

        }

    }

   

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("Daño");
        }
        if (collision.tag == "SpeedBoost")
        {
            boosting = true;
            speed = 10f;
            Destroy(collision.gameObject);
            
        }

    }

}

