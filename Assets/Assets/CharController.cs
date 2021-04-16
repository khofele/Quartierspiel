using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Class for controlling the char's animations
public class CharController : MonoBehaviour
{
    private Animator anim = new Animator();



    void FixedUpdate()
    {
        anim = GameManager.charList[GameManager.currentPlayer].GetComponent<Animator>();

        if(GameManager.instance.gameStarted == true)    // checks if game has already started
        {
            if (StoneMovement.isMovingChars[GameManager.currentPlayer] == true)     // checks if char is moving --> turns walking-animation on
            {

                anim.SetTrigger("move");
            }
            if (StoneMovement.isMoving == false)    // turns walking-animation of and switches to idle-animation if char isn't moving
            {
                anim.SetTrigger("idle");
            }
        }

    }
}
