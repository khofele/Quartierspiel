using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI TextMoneyRessource;
    public TextMeshProUGUI TextEconomyRessource;
    public TextMeshProUGUI TextSatisfactionRessource;
    public TextMeshProUGUI RoundScoreText;
    public TextMeshProUGUI TotalScoreText;



    public GameObject endScreen;
    public GameObject startScreen;
    public TextMeshProUGUI endScreenHeader;
    public TextMeshProUGUI endScreenScoreText;
    public GameObject pauseScreen;
    public GameObject rollNowScreen;
    public GameObject GameOver;

    // variables for inputfield for number of players
    public GameObject spieleranzahlScreen;
    public GameObject errormessageInvalidInput;
    public TMP_InputField inputField;

    // instance
    public static GameUI instance;

    void Awake()
    {
        instance = this;
    }
    void Update()
    {
        UpdateScoreText();
    }
    void Start()
    {
        UpdateScoreText();
    }

    //updates the player's score text
    public void UpdateScoreText()
    {
        TextMoneyRessource.text = GameManager.instance.goldRessource.ToString();
        TextEconomyRessource.text = GameManager.instance.umweltRessource.ToString();
        TextSatisfactionRessource.text = GameManager.instance.zufriedenheitRessource.ToString();
        RoundScoreText.text = GameManager.instance.roundCounter.ToString();

    }

    public void DisplayErrorMessageInvalidInput()
    {
        errormessageInvalidInput.SetActive(true);
    }

    public void DiasbleErrorMessageInvalidInput()
    {
        errormessageInvalidInput.SetActive(false);
    }

    public void DisplaySpieleranzahlScreen()
    {
        spieleranzahlScreen.SetActive(true);
    }

    public void DisableSpieleranzahlScreen()
    {
        spieleranzahlScreen.SetActive(false);
    }

    public void DisplayRollDiceScreen()
    {
        rollNowScreen.SetActive(true);
    }

    public void DisableRollDiceScreen()
    {
        rollNowScreen.SetActive(false);
    }
    public void GameOverScreen()
    {
        GameOver.SetActive(true);
        TotalScoreText.text = GameManager.instance.totalScore.ToString();
        Time.timeScale = 0.0f;

    }

    // called when the game is paused or un-paused
    public void TogglePauseScreen(bool paused)
    {
        pauseScreen.SetActive(paused);
    }

    // called when the "Resume" button is pressed
    public void OnResumeButton()
    {
        GameManager.instance.TogglePauseGame();
    }


    public void OnStartButton()
    {
        startScreen.SetActive(false);
    }

    
}