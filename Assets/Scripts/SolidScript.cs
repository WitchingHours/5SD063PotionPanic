using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidScript : MonoBehaviour
{
    public GameObject spawnObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Cursor") && Input.GetMouseButtonDown(0))
        {
            var otherPos = other.gameObject.transform.position;
            
            
            GameObject ingredient= GameObject.Instantiate(spawnObject);
            ingredient.transform.position = otherPos;
            
           
            
        }
    }
}
