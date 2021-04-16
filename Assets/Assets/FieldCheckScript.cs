using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class FieldCheckScript : MonoBehaviour
{
    
    public GameObject PlayerSelectionField;
    public GameObject BuildingToCreateOptionA;
    public GameObject BuildingToCreateOptionB;
 

    GameObject neuesGebäude;
    public bool DecisionMade;

    // current field of current player
    private GameObject field;


    private void Start()
    {
       
       // DecisionMade = true;
      
    }



    private void Update()
    {

        if (DecisionMade == true)
        {
            PlayerSelectionField.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (StoneMovement.steps == 0)
        {
            DecisionMade = false;
        }
    }


    private void OnTriggerStay(Collider other) {
 

        if (StoneMovement.steps == 0 && GameManager.instance.allowedToDisplayCanvas == true && GameManager.instance.allowedToBuySomething == true)
        {
            field = GameObject.FindWithTag("Feld" + StoneMovement.routePositions[GameManager.currentPlayer]);       // current field of current player
            Debug.Log("Fieldname:" + field.name);

            Debug.Log("Current Player " + GameManager.currentPlayer + " with Pos " + StoneMovement.routePositions[GameManager.currentPlayer]);

            switch (field.name)
            {
                case "TriggerStartfeld":
                    Debug.Log("I am Field 1");
                    //DecisionMade = false;
                    break;
                
                case "TriggerFeld2":
                    PlayerSelectionField.SetActive(true);
                    Debug.Log("I am Field 2");
                    DecisionMade = false;
                    GameManager.instance.allowedToDisplayCanvas = false;
                    break;

                case "TriggerFeld3":
                    PlayerSelectionField.SetActive(true);
                    Debug.Log("I am Field 3");
                    DecisionMade = false;
                    GameManager.instance.allowedToDisplayCanvas = false;
                    break;

                case "TriggerFeld4":
                    PlayerSelectionField.SetActive(true);
                    Debug.Log("I am Field 4");
                    DecisionMade = false;
                    GameManager.instance.allowedToDisplayCanvas = false;
                    break;

                case "TriggerFeld5":
                    PlayerSelectionField.SetActive(true);
                    Debug.Log("I am Field 5");
                    DecisionMade = false;
                    GameManager.instance.allowedToDisplayCanvas = false;
                    break;

                case "TriggerFeld6":
                    PlayerSelectionField.SetActive(true);
                    Debug.Log("I am Field 6");
                    DecisionMade = false;
                    GameManager.instance.allowedToDisplayCanvas = false;
                    break;

                case "TriggerFeld7":
                    PlayerSelectionField.SetActive(true);
                    Debug.Log("I am Field 7");
                    DecisionMade = false;
                    GameManager.instance.allowedToDisplayCanvas = false;
                    break;

                case "TriggerFeld8":
                    PlayerSelectionField.SetActive(true);
                    Debug.Log("I am Field 8");
                    DecisionMade = false;
                    GameManager.instance.allowedToDisplayCanvas = false;
                    break;

                case "TriggerFeld9":
                    PlayerSelectionField.SetActive(true);
                    Debug.Log("I am Field 9");
                    DecisionMade = false;
                    GameManager.instance.allowedToDisplayCanvas = false;
                    break;

                case "TriggerFeld10":
                    PlayerSelectionField.SetActive(true);
                    Debug.Log("I am Field 10");
                    DecisionMade = false;
                    GameManager.instance.allowedToDisplayCanvas = false;
                    break;

                case "TriggerFeld11":
                    PlayerSelectionField.SetActive(true);
                    Debug.Log("I am Field 11");
                    DecisionMade = false;
                    GameManager.instance.allowedToDisplayCanvas = false;
                    break;

                case "TriggerFeld12":
                    PlayerSelectionField.SetActive(true);
                    Debug.Log("I am Field 12");
                    DecisionMade = false;
                    GameManager.instance.allowedToDisplayCanvas = false;
                    break;

                case "Feld12":
                    PlayerSelectionField.SetActive(true);
                    Debug.Log("I am Field 13");
                    DecisionMade = false;
                    GameManager.instance.allowedToDisplayCanvas = false;
                    break;

                case "Feld13":
                    PlayerSelectionField.SetActive(true);
                    Debug.Log("I am Field 14");
                    DecisionMade = false;
                    GameManager.instance.allowedToDisplayCanvas = false;
                    break;

                case "Feld14":
                    PlayerSelectionField.SetActive(true);
                    Debug.Log("I am Field 15");
                    DecisionMade = false;
                    GameManager.instance.allowedToDisplayCanvas = false;
                    break;

                case "Feld15":
                    PlayerSelectionField.SetActive(true);
                    Debug.Log("I am Field 16");
                    DecisionMade = false;
                    GameManager.instance.allowedToDisplayCanvas = false;
                    break;

                case "Feld16":
                    PlayerSelectionField.SetActive(true);
                    Debug.Log("I am Field 17");
                    DecisionMade = false;
                    GameManager.instance.allowedToDisplayCanvas = false;
                    break;

                case "Feld17":
                    PlayerSelectionField.SetActive(true);
                    Debug.Log("I am Field 18");
                    DecisionMade = false;
                    GameManager.instance.allowedToDisplayCanvas = false;
                    break;

                case "Feld18":
                    PlayerSelectionField.SetActive(true);
                    Debug.Log("I am Field 19");
                    DecisionMade = false;
                    GameManager.instance.allowedToDisplayCanvas = false;
                    break;

                case "Feld19":
                    PlayerSelectionField.SetActive(true);
                    Debug.Log("I am Field 20");
                    DecisionMade = false;
                    GameManager.instance.allowedToDisplayCanvas = false;
                    break;

            }

        }



    }



    public void OnSelection1()
    {
        PlayerSelectionField.gameObject.SetActive(false);
        Instantiate(BuildingToCreateOptionA);
        BuildingToCreateOptionA.SetActive(true);
        DecisionMade = true;
        GameManager.instance.NextRound();
        
    }


    public void OnSelection2()
    {

        PlayerSelectionField.gameObject.SetActive(false);
        Instantiate(BuildingToCreateOptionB);
        BuildingToCreateOptionB.SetActive(true);
        DecisionMade = true;
        GameManager.instance.NextRound();

    }

      

public void Extremefield()
    {
        PlayerSelectionField.SetActive(false);
        DecisionMade = true;
        GameManager.instance.NextRound();
        
        // logic of extreme field
    }


}

