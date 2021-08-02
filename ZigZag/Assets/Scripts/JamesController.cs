using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamesController : MonoBehaviour
{
    public static JamesController instance;

    public GameObject particle;

    [SerializeField]
    public float speed;
    bool started;
    bool gameOver;
    bool directionX;
    public Rigidbody rb;
    Animator anim;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        directionX = true;
        rb = this.GetComponent<Rigidbody>();
        anim = this.GetComponent<Animator>();
        started = false;
        speed = 5;
    }

    void Update()
    {

        // if (!started)
        // {
        //     if (Input.GetMouseButtonDown(0))
        //     {
        //         rb.velocity = new Vector3(speed, 0, 0);
        //         started = true;

        //         GameManager.instance.StartGame();
        //         anim.SetTrigger("Start");
        //     }
        // }

        if (rb.position.y < 0.45 && !gameOver)
        {
            gameOver = true;
            rb.velocity = new Vector3(0, -25f, 0);

            Camera.main.GetComponent<CameraFollowJames>().gameOver = true;
            Camera.main.GetComponent<CameraFollowAJ>().gameOver = true;
            Camera.main.GetComponent<CameraFollowRemy>().gameOver = true;

            GameManager.instance.GameOver();
            // CancelInvoke("IncreaseSpeed");
        }

        if (started)
        {
            if (Input.GetMouseButtonDown(0) && !gameOver)
            {
                SwitchDirection();
            }

            // InvokeRepeating("IncreaseSpeed", 0.1f, 1f);
        }
    }

    public void Started()
    {
        if (!started)
        {
            started = true;
            rb.velocity = new Vector3(speed, 0, 0);

            GameManager.instance.StartGame();
            anim.SetTrigger("Start");
        }
    }

    void SwitchDirection()
    {
        // if (rb.velocity.z != 0)
        // {
        //     rb.velocity = new Vector3(speed, 0, 0);
        //     transform.Rotate(0, 90, 0);
        // }
        // else if (rb.velocity.x != 0)
        // {
        //     rb.velocity = new Vector3(0, 0, speed);
        //     transform.Rotate(0, 270, 0);
        // }
        // else if (rb.velocity == Vector3.zero)
        // {
        //     rb.velocity = new Vector3(speed, 0, 0);
        // }
        if (directionX == true)
        {
            rb.velocity = new Vector3(0, 0, speed);
            transform.Rotate(0, 270, 0);
            directionX = false;
        }
        else if (directionX == false)
        {
            rb.velocity = new Vector3(speed, 0, 0);
            transform.Rotate(0, 90, 0);
            directionX = true;
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Diamond")
        {
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().score += 3;
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().diamondCount += 1;
            GameObject part = Instantiate(particle, col.gameObject.transform.position, particle.transform.rotation) as GameObject;
            Destroy(col.gameObject);
            Destroy(part, 1f);
        }
    }

    // void IncreaseSpeed()
    // {
    //     speed = speed + 0.00005f;
    // }
}
