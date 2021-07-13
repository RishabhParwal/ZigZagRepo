using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowAJ : MonoBehaviour
{
    public GameObject AJ;
    Vector3 offset;
    public float smoothFactor = 0.5f;
    public bool gameOver;
    public bool lookAtTarget = false;

    void Start()
    {
        offset = transform.position - AJ.transform.position;
    }

    void LateUpdate()
    {
        if (!gameOver)
        {
            Vector3 newposition = AJ.transform.position + offset;
            transform.position = Vector3.Slerp(transform.position, newposition, smoothFactor);

            if (lookAtTarget)
            {
                transform.LookAt(AJ.transform);
            }
            // if (!gameOver)
            // {
            //     Follow();
            // }
        }
    }

    void Update()
    {
        if (PlayerPrefs.GetString("Character") == "AJ")
        {
            this.enabled = true;
        }
        if (PlayerPrefs.GetString("Character") == "James")
        {
            this.enabled = false;
        }
    }

    // void Follow()
    // {
    //     Vector3 pos = transform.position;
    //     Vector3 targetPos = AJ.transform.position - offset;
    //     pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
    //     transform.position = pos;
    // }
}
