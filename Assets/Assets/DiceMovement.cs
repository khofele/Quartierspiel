using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceMovement : MonoBehaviour
{


    public static Rigidbody rb;
    public static Vector3 diceVelocity;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        diceVelocity = rb.velocity;
        if (Input.GetKeyDown(KeyCode.Space) && GameManager.instance.allowedToRoll == true)
        {
            //   isHappening = true;
            
            RollTheDice();
            GameUI.instance.DisableRollDiceScreen();
            
        }
    }


    void RollTheDice() { 
       
        // hier sollten eigentlich Constraints eingefügt werden, sodass der neue Würfel erst nach unten fällt, wenn LEERTASTE gedrückt wird
        rb.constraints = RigidbodyConstraints.None;
        //TextScript.diceNumber = 0;
        float dirX = Random.Range(0, 1000);
        float dirY = Random.Range(0, 1000);
        float dirZ = Random.Range(0, 1000);

        transform.position = new Vector3(-120, 8, 11);
        transform.rotation = Quaternion.identity;
        rb.AddForce(transform.up * 1000);
        rb.AddTorque(dirX, dirY, dirZ);
        GameManager.instance.allowedToRoll = false;
        // isHappening = false;


    }

}


