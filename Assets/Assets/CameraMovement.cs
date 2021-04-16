using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
   

    public static Transform player;
    public Vector3 offset;
    public Vector3 additionalOffset;
    public static GameObject PlayerObject;
    float distance;
    Vector3 playerPrevPos, playerMoveDir;

 

    // Use this for initialization
    void Start()
    {
        PlayerObject = GameManager.charList[GameManager.currentPlayer];
        player = GameManager.charList[GameManager.currentPlayer].transform;
        offset = transform.position - PlayerObject.transform.position;

        distance = offset.magnitude;
        playerPrevPos = PlayerObject.transform.position;
    }

    void LateUpdate()
    {


        playerMoveDir = PlayerObject.transform.position - playerPrevPos;
       // playerMoveDir.Normalize();
        transform.position = PlayerObject.transform.position - playerMoveDir * distance;

        transform.LookAt(PlayerObject.transform.position);

        playerPrevPos = PlayerObject.transform.position;

        transform.position = player.position + additionalOffset;
    }



}
