using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayBuilding : MonoBehaviour
{
    public BuildingScript buildings;

    public TextMeshProUGUI buildingText;
    public TextMeshProUGUI descriptionText;
    public Image backGround;
    public TextMeshProUGUI buildingcostsText;
    public TextMeshProUGUI geldProRundeText;
    public TextMeshProUGUI ecoProRundeText;
    public TextMeshProUGUI zufProRundeText;



    private void Start()
    {
        buildingText.text = buildings.buildingName;
        descriptionText.text = buildings.description;

        backGround.sprite = buildings.backgroundImage;
        buildingcostsText.text = buildings.buildingcosts.ToString();
        geldProRundeText.text = buildings.geldProRunde.ToString();
        ecoProRundeText.text = buildings.ecoProRunde.ToString();
        zufProRundeText.text = buildings.zufProRunde.ToString();


    }
}
