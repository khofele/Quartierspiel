using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabdetection : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isOccupied;

    public Transform[] prefabdetectorPositionsArray;
    public GameObject[] array;





    private void OnTriggerStay(Collider other)
    {
        isOccupied = true;
        Debug.Log("is occupied");
    }


    public static void ChooseSpace()

    {
        
    }


}
