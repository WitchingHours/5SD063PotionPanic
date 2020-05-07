using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEyes : MonoBehaviour
{
    public GameObject eyes, blink;
    public float speed, blinkTime;
    float timeBetweenBlink;
    public bool move;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Blinking());
        timeBetweenBlink = Random.Range(1, 3);
        move = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            transform.position = Vector3.LerpUnclamped(transform.position, eyes.transform.position, speed);
        }      
    }

    IEnumerator Blinking()
    {
        yield return new WaitForSeconds(timeBetweenBlink);
        blink.SetActive(true);
        StartCoroutine(OpenEyes());
    }

    IEnumerator OpenEyes()
    {
        yield return new WaitForSeconds(blinkTime);
        blink.SetActive(false);
        timeBetweenBlink = Random.Range(2, 4);
        StartCoroutine(Blinking());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Wisp"))
        {
            move = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Wisp"))
        {
            move = true;
        }
    }
}
