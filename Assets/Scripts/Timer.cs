using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    
    public float timeStart;
    public float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = timeStart;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        string counter = Mathf.Floor(timeLeft / 60).ToString()+":" + Mathf.Floor(timeLeft % 60).ToString();
        this.gameObject.GetComponent<UnityEngine.UI.Text>().text =counter;
        if (timeLeft < 0) 
        {
            SceneManager.LoadSceneAsync("EndScene");
        }
    }
    
}
