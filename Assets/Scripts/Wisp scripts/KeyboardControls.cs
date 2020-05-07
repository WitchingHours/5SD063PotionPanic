using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControls : MonoBehaviour
{
    //Variables for movement
    Rigidbody rb;
    float speed;
    public float sleepySpeed, normalSpeed;
    public string axisX, axisY;
    float getInputH, getInputV;

    public GameObject player;
    StatusScript status;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        status = player.GetComponent<StatusScript>();
    }

    private void Update()
    {
        if (status.playerStatus == StatusScript.States.sleepy)
        {
            if (speed != sleepySpeed)
            {
                speed = sleepySpeed;
            }
        }

        else
        {
            if (speed != normalSpeed)
            {
                speed = normalSpeed;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(status.playerStatus != StatusScript.States.mirrored)
        {
            getInputH = Input.GetAxis(axisX);
            getInputV = Input.GetAxis(axisY);
        }

        else
        {
            getInputH = -Input.GetAxis(axisX);
            getInputV = -Input.GetAxis(axisY);
        }

        rb.velocity = new Vector3(getInputH * Time.deltaTime * speed, getInputV * Time.deltaTime * speed, 0f);
    }
}
