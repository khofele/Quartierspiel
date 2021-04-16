using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "card", menuName = "Cards")]

public class CardScript : ScriptableObject


{
    public string cardName;
    public string description;

    public Sprite backgroundImage;
    public int moneyBonus;
    public int ecoBonus;
    public int satisfactionBonus;
 
    

    public void Print()
    {

    }
}
