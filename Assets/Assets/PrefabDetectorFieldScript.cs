using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabDetectorFieldScript: MonoBehaviour
{

    public bool prefabDetectionFieldOccupied;


    public void OnTriggerStay(Collider other)
    {
       
            prefabDetectionFieldOccupied = true;
               Debug.Log("Occupied");
        Debug.Log(prefabDetectionFieldOccupied);
                


    }
    

}
