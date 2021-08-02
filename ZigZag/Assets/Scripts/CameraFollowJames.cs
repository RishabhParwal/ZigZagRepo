using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowJames : MonoBehaviour
{
    public GameObject james;
    Vector3 offset;
    public float smoothFactor = 0.5f;
    public float lerpRate = 2f;
    public bool gameOver;
    public bool lookAtTarget = false;

    void Start()
    {
        offset = transform.position - james.transform.position;
    }

    void LateUpdate()
    {
        if (!gameOver)
        {
            // Vector3 newposition = AJ.transform.position + offset;
            // transform.position = Vector3.Slerp(transform.position, newposition, smoothFactor);

            // if (lookAtTarget)
            // {
            //     transform.LookAt(AJ.transform);
            // }
            Follow();
        }
    }
    void Update()
    {
        if (PlayerPrefs.GetString("Character") == "James")
        {
            this.enabled = true;
        }
        if (PlayerPrefs.GetString("Character") == "AJ")
        {
            this.enabled = false;
        }
        if (PlayerPrefs.GetString("Character") == "Remy")
        {
            this.enabled = false;
        }
    }

    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = james.transform.position + offset;
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
