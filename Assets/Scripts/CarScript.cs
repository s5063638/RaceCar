using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarScript : MonoBehaviour {

    public float speed;
    public float turnSpeed;
    public bool isMoving;
    public Rigidbody carRigidbody;

    public float accelerateLimit;
    public float reverseLimit;
    public bool canMove;

    public AudioSource carEngine;

    // Use this for initialization
    void Start ()
    {
        carRigidbody = this.GetComponent<Rigidbody>();
        canMove = false;

        carEngine = this.gameObject.GetComponent<AudioSource>();

        string currentCar = PlayerPrefs.GetString("CarChosen");

        if(PlayerPrefs.GetString(currentCar + "U1") == "YES")
        {
            speed = speed + (speed * 0.05f);
            accelerateLimit += 5;
        }
        if(PlayerPrefs.GetString(currentCar + "U2") == "YES")
        {
            accelerateLimit += 63;
        }
        if(PlayerPrefs.GetString(currentCar + "U3") == "YES")
        {
            turnSpeed += 0.1f;
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Water")
        {
            SceneManager.LoadScene("Crashed");
        }
    }

	// Update is called once per frame
	void FixedUpdate ()
    {
        if (canMove == true)
        {
            if (carRigidbody.velocity.magnitude < 1.0f)
            {
                isMoving = false;
            }
            else
            {
                isMoving = true;
            }

            if (Input.GetKey(KeyCode.S))
            {
                Reverse();
            }
            else if (Input.GetKey(KeyCode.W))
            {
                Accelerate();
            }


            if (isMoving)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    transform.Rotate(new Vector3(0.0f, -turnSpeed, 0.0f));
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    transform.Rotate(new Vector3(0.0f, turnSpeed, 0.0f));
                }
            }

            //if (Input.touchCount > 0)
            //{
            //    Touch touch = Input.GetTouch(0);
            //    if (touch.position.x < Screen.width / 2)
            //    {
            //        //Left screen touch
            //        Reverse();

            //    }
            //    else if (touch.position.x > Screen.width / 2)
            //    {
            //        //Right screen touch
            //        Accelerate();
            //    }

            //    if (isMoving)
            //    {
            //        Vector3 accelerometerDir = Vector3.zero;

            //        accelerometerDir.x = Input.acceleration.x;

            //        if (accelerometerDir.x < -0.1f)
            //        {
            //            //Tilted left
            //            transform.Rotate(new Vector3(0.0f, -turnSpeed, 0.0f));
            //        }
            //        else if (accelerometerDir.x > 0.1f)
            //        {
            //            //Tilted right
            //            transform.Rotate(new Vector3(0.0f, turnSpeed, 0.0f));
            //        }
            //    }
            //}
        }
    }

    void Update()
    {
        float min = 1.0f;
        float max = 2.0f;

        float mod = max - min;

        float calc = min + (carRigidbody.velocity.magnitude / accelerateLimit) * mod;

        if(calc > max)
        {
            calc = max;
        }
        carEngine.pitch = calc;
    }

    public void Accelerate()
    {
        if (carRigidbody.velocity.magnitude < accelerateLimit)
        {
            carRigidbody.AddForce(transform.forward * speed);
        }
    }
    public void Reverse()
    {
        if (carRigidbody.velocity.magnitude < reverseLimit)
        {
            carRigidbody.AddForce(-(transform.forward) * ((speed * 3) / 4));
        }
    }
}