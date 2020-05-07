using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    public GameObject anyIngredient;
    public GameObject otherPlayer;
    public bool buttonPressed = false;
    public float baseCountdown = 2;
    float countDown = 0;
    public ParticleSystem splash;
    int potionId;
    //public GameObject sideTable;
    public bool leftShelf;

    // Start is called before the first frame update
    void Start()
    {
        potionId = 1;
        countDown = baseCountdown;
    }

    // Update is called once per frame
    void Update()
    {
       


        if (buttonPressed) 
        {
            
            countDown -= Time.deltaTime;
            if (countDown <= 0) 
            {
               
                countDown = baseCountdown;
                buttonPressed = false;
               
            }
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject obj = anyIngredient;
            IngredientValue scr = obj.GetComponent<IngredientValue>();
            GetComponent<Animation>().Play();
            StatusScript statScr = otherPlayer.GetComponent<StatusScript>();
            buttonPressed = true;
            Debug.Log(scr.getPotion(potionId,leftShelf,statScr));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        
        
        IngredientValue scr = obj.GetComponent<IngredientValue>();
        if (scr != null) 
        { 
            potionId = potionId * scr.getIngredientPrime(scr.myIngredient);
            scr.getIngredientsFromId(potionId);
            

             
        }

        
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject obj = collision.gameObject;


        IngredientValue scr = obj.GetComponent<IngredientValue>();
        if (scr != null)
        {
            potionId = potionId / scr.getIngredientPrime(scr.myIngredient);
            scr.getIngredientsFromId(potionId);
            
        }
    }
}
