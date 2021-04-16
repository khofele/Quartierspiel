using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayCard : MonoBehaviour
{

    public CardScript card;

    public TextMeshProUGUI cardText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI ecoText;
    public TextMeshProUGUI satisfactionText;



    // Start is called before the first frame update
   private void Start()
    {
        cardText.text = card.cardName;
        descriptionText.text = card.description;

        
        goldText.text = card.moneyBonus.ToString();
        ecoText.text = card.ecoBonus.ToString();
        satisfactionText.text = card.satisfactionBonus.ToString();



    }

   
}
