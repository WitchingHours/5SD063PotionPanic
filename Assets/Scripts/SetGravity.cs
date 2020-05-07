using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGravity : MonoBehaviour
{
    public float xGrav;
    public float yGrav;
    public float zGrav;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 grav = new Vector3(xGrav, yGrav, zGrav);
        Physics.gravity=grav;
    }

    // Update is called once per frame
    void Update()
    {
        //remove after testing
        Vector3 grav = new Vector3(xGrav, yGrav, zGrav);
        Physics.gravity = grav;
    }
}
