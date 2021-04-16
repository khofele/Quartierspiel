using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewName2", menuName = "Buildings")]

public class BuildingScript : ScriptableObject
{
    public string buildingName;
    public string description;

    public Sprite backgroundImage;
    public int buildingcosts;
    public int geldProRunde;
    public int ecoProRunde;
    public int zufProRunde;


    public void print()
    {

    }
   
}
