using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsManager : MonoBehaviour
{
    States controls;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (controls)
        {
            case States.motionControls:
                break;

            case States.other:
                break;
        }
    }

    enum States
    {
        motionControls,
        other,
    }
}
