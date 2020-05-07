using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class StatusScript : MonoBehaviour
{
    public void SetStatus(States state) 
    {
        playerStatus = state;
        Debug.Log("Satus :" + playerStatus.ToString());
    }
    public enum States
    {
        normal,
        sleepy,
        stormy,
        mirrored,
    }

    public States playerStatus;
    public GameObject thunder;
    public float statusLength;
    bool statusChanged;

    // Start is called before the first frame update
    void Start()
    {
        playerStatus = States.normal;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (playerStatus)
        {
            case States.normal:
                thunder.SetActive(false);
                statusChanged = false;
                break;

            case States.sleepy:
                thunder.SetActive(false);
                if (!statusChanged)
                {
                    StartCoroutine(EndStatus());
                    statusChanged = true;
                }
                break;

            case States.stormy:
                thunder.SetActive(true);
                if (!statusChanged)
                {
                    StartCoroutine(EndStatus());
                    statusChanged = true;
                }
                break;

            case States.mirrored:
                if (!statusChanged)
                {
                    StartCoroutine(EndStatus());
                    statusChanged = true;
                }
                break;
        }
    }



    IEnumerator EndStatus()
    {
        yield return new WaitForSeconds(statusLength);
        playerStatus = States.normal;
    }

}
