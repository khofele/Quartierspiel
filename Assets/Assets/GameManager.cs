using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class GameManager : MonoBehaviour
{
    public bool paused;
    public int goldRessource;
    public int umweltRessource;
    public int zufriedenheitRessource;
    public int roundCounter;
    public int maxCount;
    public bool freshRound;
    public bool allowedToRoll;
    public bool allowedToDisplayCanvas;
    public bool allowedToMove;
    public bool allowedToBuySomething;
    public bool gameStarted;

    public int totalScore;

    public Transform[] prefabDetectors;
  

    // instance
    public static GameManager instance;

    // variables for players
    public int chars;
    public GameObject charPrefab;
    public Vector3 spawnPosition = new Vector3(75, 1, -75);
    public static List<GameObject> charList = new List<GameObject>();

    // player 1 --> you need at least on player to play the game
    public GameObject player1;

    public static int currentPlayer;
    

    void Start()
    {
        currentPlayer = 0;
    }

    void Awake()
    {
        // input field for number of players
        TMP_InputField input = GameUI.instance.inputField;
        var se = new TMP_InputField.SubmitEvent();
        se.AddListener(SubmitPlayer);
        input.onEndEdit = se;


        chars = 1;
        instance = this;
        roundCounter = 1;
        allowedToRoll = false;
        allowedToMove = false;
        allowedToDisplayCanvas = false;
        allowedToBuySomething = false;

        // add player 1 to list, add player 1's position to position-list
        charList.Add(player1);
        StoneMovement.routePositions.Add(0);


        GameUI.instance.DisplaySpieleranzahlScreen();
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            TogglePauseGame();
        }


        if (allowedToRoll == true && allowedToMove == false && gameStarted)
        {
            GameUI.instance.DisplayRollDiceScreen();
        }

        // GameOver Logic

        if (roundCounter == maxCount)
        {
            GameUI.instance.GameOverScreen();
        }

        if (goldRessource <= 0)
        {
            GameUI.instance.GameOverScreen();
            Time.timeScale = 0.0f;
            //Display Game Over Screen
        }

        if ( umweltRessource <= 0)
        {
            GameUI.instance.GameOverScreen();
            Time.timeScale = 0.0f;
            //Display Game Over Screen
        }

        if (zufriedenheitRessource <= 0)
        {
            GameUI.instance.GameOverScreen();
            Time.timeScale = 0.0f;
            //Display Game Over Screen
        }

        totalScore = goldRessource + (umweltRessource*2) + (zufriedenheitRessource*3);
    }

    public void TogglePauseGame()
    {
        paused = !paused;

        if (paused)
            Time.timeScale = 0.0f;
        else
            Time.timeScale = 1.0f;

        GameUI.instance.TogglePauseScreen(paused);
    }

    // adds to the player's score
    public void AddScore(int scoreToGive)
    {

    }

    public void CalculateGoods()
    {
        ScriptForPrefab[] Buildings = GameObject.FindObjectsOfType<ScriptForPrefab>();

        int totalGold = 0;
        int totalUmwelt = 0;
        int totalZufriedenheit = 0;

        for (int i = 0; i < Buildings.Length; i++)
        {
            totalGold += Buildings[i].gold;
            totalUmwelt += Buildings[i].umwelt;
            totalZufriedenheit += Buildings[i].zufriedenheit;
        }

        goldRessource += totalGold;
        umweltRessource += totalUmwelt;
        zufriedenheitRessource += totalZufriedenheit;
    }

   public void NextRound()
    {
 
        CalculateGoods();
        allowedToRoll = true;
        allowedToMove = false;
        allowedToDisplayCanvas = false;

        ++currentPlayer;
        currentPlayer %= charList.Count;

        if((currentPlayer %= charList.Count) == 0)
        {
            roundCounter++;
        }

 
        // define variables for camera for next round
        CameraMovement.PlayerObject = charList[currentPlayer];
        CameraMovement.player = charList[currentPlayer].transform;

        Debug.Log("Current Player is now: " + currentPlayer + " with Position " + StoneMovement.routePositions[currentPlayer]);
    }

    // get user input for number of players
    // check if input has the right format and check if input is at least 1
    public void SubmitPlayer(string arg)
    {
        Debug.Log("Input: " + arg);
        int value;
        bool successRightFormat = int.TryParse(arg, out value);
        if (successRightFormat && int.Parse(arg) >= 1 && Input.GetKeyDown(KeyCode.Return))
        {
            chars = int.Parse(arg);
            Debug.Log("chars:" + chars);
            AddPlayers();
            GameUI.instance.DisableSpieleranzahlScreen();
            gameStarted = true;
            allowedToRoll = true;
            GameUI.instance.DisplayRollDiceScreen();
        }
        else if(successRightFormat == false || value < 1)
        {
            GameUI.instance.DisplayErrorMessageInvalidInput();
        }
    }


    // instantiate and add players, their "state" (if they're moving or not), and their position to lists
    public void AddPlayers()
    {
        StoneMovement.isMovingChars.Add(false); // moving-state of player 1
        for (int i = 1; i < chars; i++)
        {
            GameObject playerClone = Instantiate(charPrefab);
            playerClone.GetComponent<StoneMovement>().MainCamera = Camera.main;
            Camera followCam = GameObject.FindWithTag("followCam").GetComponent<Camera>();
            playerClone.GetComponent<StoneMovement>().PlayerCamera = followCam;
            Transform boardOverview = GameObject.FindWithTag("boardOverview").GetComponent<Transform>();
            playerClone.GetComponent<StoneMovement>().boardOverview = boardOverview;
            PathMovement route = GameObject.FindWithTag("route").GetComponent<PathMovement>();
            playerClone.GetComponent<StoneMovement>().currentRoute = route;


            charList.Add(playerClone);
            StoneMovement.routePositions.Add(0);
            StoneMovement.isMovingChars.Add(false);
        }
    }
 }