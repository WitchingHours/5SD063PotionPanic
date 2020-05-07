using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Ingredients  // https://primes.utm.edu/lists/small/10000.txt list of primes
{
    none = 1,
    batwing = 2,
    moonwater = 3,
    redMushroom = 5,
    chamomile = 7,
    butterfly = 11,
    honey = 13,
    crystal = 17
}


/*explanation of system: each ingredient is connected to a diffrent prime. 
 All of the ingredients primes are multiplied with each other to get the number called potionId.
 potionId 1 means empty.
 Since all the factors are prime modulo(%) can be used to check if the potion contains a specific ingredient.
 Multipplying potionId with an ingredients prime adds the ingredient
 Dividing with an ingredients prime removes the ingredient. DO NOT try to remove an ingredient that potionId does not contain.

    none of these functions directly modifies potionId of the object accessing them.
*/


public class IngredientValue : MonoBehaviour
{
   
    public Ingredients myIngredient;
    
    public int getIngredientPrime(Ingredients ingredient) 
    {
        return (int)ingredient;
   
            

   
        
    }

    public string getIngredientFromPrime(int prime) 
    {
        return ((Ingredients)prime).ToString();

      
    }

    public string getPotion(int potionId,bool leftShelf,StatusScript target) //gets potion from recipie 
    {

        Vector3 vec = new Vector3(0, 0, 0);//-15,10,0 left 15,10,0 right
        int location;
        if (leftShelf)
        {
            location = -1;//left=-1 right=1
        }
        else 
        {
            location = 1;
        }

        switch (potionId) //case ingredient1 * ingredient2 * ingredient3... etc.
        {
            case (int)Ingredients.batwing * (int)Ingredients.chamomile * (int)Ingredients.moonwater:
                //vec.Set(13*location, 10, 0);
                target.SetStatus(StatusScript.States.sleepy);
                 return "Moon Tea";
            case (int)Ingredients.crystal * (int)Ingredients.honey * (int)Ingredients.butterfly:
                vec.Set(15 * location, 10, 0);
                GameObject.Instantiate(Resources.Load("Potions/Liquid gold"),vec,Quaternion.identity); return "Liquid gold";
            default: 
                 return "None";
        }
        
        
    }

    public void getIngredientsFromId(int id) 
    {

        int[] allTheIngredients = {(int)Ingredients.batwing,(int)Ingredients.butterfly,(int)Ingredients.chamomile,
            (int)Ingredients.crystal,(int)Ingredients.honey,(int)Ingredients.moonwater,(int)Ingredients.redMushroom };
        string str="";
        int diffrentTypesOfIngedients = 7;//amount of ingredients in game
        for (int i=0;i< diffrentTypesOfIngedients; i++) 
        {
            int count = 0;
            while(id % allTheIngredients[i] == 0) 
            {
                id = id / allTheIngredients[i];
                count++;
            }
            if (count > 0) 
            { 
                str+=count.ToString()+":"+getIngredientFromPrime(allTheIngredients[i])+" ";
            }
        }
        Debug.Log(str);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
