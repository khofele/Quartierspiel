using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    Text text;
    public int diceNumber;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = diceNumber.ToString();
    }

}

