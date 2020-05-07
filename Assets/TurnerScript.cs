using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnerScript : MonoBehaviour
{
    Vector3 mousePos;
    string numbers;
    public int correctNumbers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        if(numbers.Length == 4)
        {
            int numbersInt = int.Parse(numbers);
            if(numbersInt == correctNumbers)
            {
                Debug.Log("That's correct!");
                numbers = "";
            }
            else
            {
                Debug.Log("Wrong!");
                numbers = "";
            }
        }
    }

    private void FixedUpdate()
    {
        transform.localRotation = Quaternion.Euler(mousePos.y * 54f - 27f, 0, -mousePos.x * 54f + 27f);
    }

    private void OnTriggerEnter(Collider other)
    {
        numbers += other.gameObject.name;
        Debug.Log(numbers);
    }
}
