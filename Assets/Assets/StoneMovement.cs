using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMovement : MonoBehaviour
{
    
    public PathMovement currentRoute;

    // list for positions of chars
    public static List<int> routePositions = new List<int>();
    public int routePosition;

    public static int steps;

    public static bool isMoving;
    public static bool isHappening;
    public static float coolDownTime;
    public static float coolDownRemaining;

    public int cameraSpeed;
    public Transform boardOverview;

    public int moveSpeed;
    public Camera MainCamera;
    public Camera PlayerCamera;
   // public Camera DiceCam;
    Vector3 diceVelocity = DiceMovement.diceVelocity;

    // list for bools of every char --> true if char is moving
    public static List<bool> isMovingChars = new List<bool>();


    void Start()
    {
        isHappening = false;

    }

    void Update()
    {
        // player moves if enter is pressed

        if (Input.GetKeyDown(KeyCode.Return) && !isMoving && DiceCheckZoneScript.diceNumberThrown > 0 && GameManager.instance.allowedToMove == true && GameManager.instance.gameStarted == true)
        {

            Debug.Log("Current Player " + GameManager.currentPlayer);

            steps = DiceCheckZoneScript.diceNumberThrown;                                                              

            Debug.Log("Dice Rolled " + steps);

            // get the current position of the active player
            routePosition = routePositions[GameManager.currentPlayer];

            // starts coroutine for active player
            StartCoroutine(Move());  
        }

        // checks if something happens (player moves) --> switches to player camera or board overview
        if (isHappening == true)
        {
            MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, PlayerCamera.transform.position, cameraSpeed*Time.deltaTime);
            MainCamera.transform.rotation = Quaternion.Lerp(MainCamera.transform.rotation, PlayerCamera.transform.rotation, cameraSpeed * Time.deltaTime);
        }
        if (isHappening == false)
        {
            MainCamera.enabled = true;
            PlayerCamera.enabled = false;
            MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, boardOverview.transform.position, cameraSpeed * Time.deltaTime);
            MainCamera.transform.rotation = Quaternion.Lerp(MainCamera.transform.rotation, boardOverview.transform.rotation, cameraSpeed * Time.deltaTime);
        }

        PlayerLocation();

    }

    IEnumerator Move()
    {
        if (isMoving ==true)
        {
            yield break;
        }

        isMoving = true;                // player is moving
        isHappening = true;             // something is happening --> camera needs to switch the view             
        
        while (steps > 0)
        {
            isMovingChars[GameManager.currentPlayer] = true;    // active player walks
            routePosition++;
            routePosition %= currentRoute.childNodeList.Count;

            routePositions[GameManager.currentPlayer] = routePosition;       // saves the new position of the current player


            Vector3 nextPos = currentRoute.childNodeList[routePosition].position;
            while (MoveToNextNode(nextPos)) { yield return null;}

            yield return new WaitForSeconds(0.1f);
            steps--;
            //routePosition++;
        }
       


        isMoving = false;
        isHappening = false;

        isMovingChars[GameManager.currentPlayer] = false;      // active player is done with walking

        GameManager.instance.allowedToMove = false;
        GameManager.instance.allowedToDisplayCanvas = true;
        GameManager.instance.allowedToBuySomething = true;



    }

  

    bool MoveToNextNode(Vector3 goal)
    {
        return goal != (GameManager.charList[GameManager.currentPlayer].transform.position = Vector3.MoveTowards(GameManager.charList[GameManager.currentPlayer].transform.position, goal, moveSpeed * Time.deltaTime));

    }




    public void PlayerLocation()
    {
        if (GameManager.charList[GameManager.currentPlayer].transform.position.x == -75 && GameManager.charList[GameManager.currentPlayer].transform.position.z == -75)
        {
            GameManager.charList[GameManager.currentPlayer].transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (GameManager.charList[GameManager.currentPlayer].transform.position.x == -75 && GameManager.charList[GameManager.currentPlayer].transform.position.z == 75)
        {
            GameManager.charList[GameManager.currentPlayer].transform.rotation = Quaternion.Euler(0, 90, 0);

        }

        if (GameManager.charList[GameManager.currentPlayer].transform.position.x == 75 && GameManager.charList[GameManager.currentPlayer].transform.position.z == 75)
        {
            GameManager.charList[GameManager.currentPlayer].transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (GameManager.charList[GameManager.currentPlayer].transform.position.x == 75 && GameManager.charList[GameManager.currentPlayer].transform.position.z == -75)
        {
            GameManager.charList[GameManager.currentPlayer].transform.rotation = Quaternion.Euler(0, -90, 0);
        }
    }



}


