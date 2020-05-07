using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public bool grab, pickupOk, inRift;
    public GameObject wisp;
    bool justDropped;
    Vector3 prevPos; 
    public Vector3 startPos; 
    public float lerpSpeed = 0.1f, throwSpeed;
    Rigidbody rig;

    //variables for rift behavior
    public float minRot, maxRot;
    float randomX, randomY, randomZ;
    RiftScript rift;

    // Start is called before the first frame update
    void Start()
    {
        rig = this.gameObject.GetComponent<Rigidbody>();
        prevPos = this.gameObject.GetComponent<Rigidbody>().position;
        justDropped = false;
        startPos = transform.position;
        wisp = null;
        randomX = Random.Range(0, 10f);
        randomY = Random.Range(0, 10f);
        randomZ = Random.Range(minRot, maxRot);
        rift = GameObject.FindGameObjectWithTag("Rift").GetComponent<RiftScript>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && pickupOk)
        {
            grab = true;
        }

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            grab = false;
        }
    }

    void FixedUpdate()
    {        
        int basez = -2;
        if (wisp != null) { 
            Vector3 temp = wisp.transform.position; 
        
            temp.z = basez;
     
            Vector3 newPos = Vector3.Lerp(rig.position, temp, lerpSpeed);
        
            if (grab)
            {
                rig.MovePosition(newPos);
                rig.useGravity = false;
                Vector3 stop = new Vector3(0, 0, 0);
                rig.velocity = stop;
                justDropped = true;
            }

            else if (justDropped && !inRift)
            {
                rig.useGravity = true;
                justDropped = false;

                Vector3 toss = (temp - newPos) * throwSpeed;
                rig.velocity = toss;

                if (transform.position.y < -9f)
                {
                    transform.position = new Vector3(startPos.x, 13f, startPos.z);
                }
            }
        }
        if (inRift&&!grab )
        {
            rig.velocity = Vector3.zero;
            rig.useGravity = false;
            transform.Translate(Vector3.down * Time.deltaTime * rift.riftSpeed, Space.World);
            transform.Rotate(new Vector3(randomX, randomY, randomZ) * Time.deltaTime, Space.World);

            if (transform.position.y < -9f)
            {
                transform.position = new Vector3(transform.position.x, 13f, transform.position.z);
            }
        }
        else if(!grab)
        {
            rig.useGravity = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cursor"))
        {
            wisp = other.gameObject;
            pickupOk = true;
        }

        else if (other.gameObject.CompareTag("Rift"))
        {
            inRift = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Cursor"))
        {
            pickupOk = false;
        }

        else if (other.gameObject.CompareTag("Rift"))
        {
            inRift = false;
        }
    }
}
