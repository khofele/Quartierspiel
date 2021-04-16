using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DiceCheckZoneScript : MonoBehaviour
{

    public static Vector3 diceVelocity;
    public static int diceNumberThrown;
    public static bool diceWasThrown;
    public GameObject dice;
    public Vector3 dicePosition;
        
    // Update is called once per frame

   
    void FixedUpdate()
    {
        diceVelocity = DiceMovement.diceVelocity;
        
    }

    void OnTriggerStay(Collider col)
    {

        // sobald der Würfel sich nicht mehr beweg, wird geprüft auf welcher Seite er liegt und das auch nur , wenn er nicht geworfen wurde (Hängt mit dem Respawn zusammen)

        if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f)
          {
            switch (col.gameObject.name)
            {
                case "Side1":

                    diceNumberThrown = 6;
                    //TextScript.diceNumber = diceNumberThrown;
                    Debug.Log("Number " + diceNumberThrown + "rolled");
                                      
                     break;
                case "Side2":
                    diceNumberThrown = 5;
                    //TextScript.diceNumber = diceNumberThrown;
                    Debug.Log("Number " + diceNumberThrown + "rolled");
                    
                   
                    break;
                case "Side3":
                    diceNumberThrown = 4;
                    //TextScript.diceNumber = diceNumberThrown;
                    Debug.Log("Number " + diceNumberThrown + "rolled");
                    
                   
                    break;
                case "Side4":

                    diceNumberThrown = 3;
                    //TextScript.diceNumber = diceNumberThrown;
                    Debug.Log("Number " + diceNumberThrown + "rolled");
                  
                  
                    break;
                case "Side5":
                    diceNumberThrown = 2;
                    //TextScript.diceNumber = diceNumberThrown;
                    Debug.Log("Number " + diceNumberThrown + "rolled");
                
                    
                    break;
                case "Side6":
                    diceNumberThrown = 1;
                    //TextScript.diceNumber = diceNumberThrown;
                    Debug.Log("Number " + diceNumberThrown + "rolled");
                 
                   
                    break;
            }
        }

      // wenn der Würfel still liegt und geworfen wurde und seine Zahl nicht 0 ist, wird die Coroutine SpawnNewDice getriggert

        if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f && GameManager.instance.freshRound == false && diceNumberThrown != 0)
        {
            //  GameObject.Destroy(dice);

            StartCoroutine("SpawnNewDice");
            GameManager.instance.allowedToMove = true;
            
        }
    }

   IEnumerator SpawnNewDice()
    {
        GameObject.Destroy(dice);           //zerstört den Würfel
        dice = (GameObject)Instantiate(dice, dicePosition, Quaternion.identity);    // spawnt ihn neu
        dice.name = "sa";
        yield return null;
        dice.GetComponent<DiceMovement>().enabled = true;
      //  diceWasThrown = false;
     
     
            
   }


}
