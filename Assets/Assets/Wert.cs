using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wert : MonoBehaviour
{
    public static int Würfelergebnis;
    public static bool alterWert;
    public GameObject Wertübergabe;

    void Update()
    {
        Würfelergebnis = MyPrefabInstantiator.currentNumber;
        //Debug.Log(Würfelergebnis);

        if (Würfelergebnis != 0)
        {

            switch (Würfelergebnis)
            {
                case 1: Debug.Log("es ist eine 1");
                    //DontDestroyOnLoad(this.gameObject);
                    DontDestroyOnLoad(GameObject.Find("Wert1"));
                    //Destroy wenn Wert geholt -> Befehl in entsprechendes Script aus Game Scene aufgreifen
                    break;

                case 2:
                    Debug.Log("es ist eine 2");
                    //DontDestroyOnLoad(this.gameObject);
                    DontDestroyOnLoad(GameObject.Find("Wert2"));
                    break;

                case 3:
                    Debug.Log("es ist eine 3");
                    //DontDestroyOnLoad(this.gameObject);
                    DontDestroyOnLoad(GameObject.Find("Wert3"));
                    break;

                case 4:
                    Debug.Log("es ist eine 4");
                    //DontDestroyOnLoad(this.gameObject);
                    DontDestroyOnLoad(GameObject.Find("Wert4"));
                    break;

                case 5:
                    Debug.Log("es ist eine 5");
                    //DontDestroyOnLoad(this.gameObject);
                    DontDestroyOnLoad(GameObject.Find("Wert5"));
                    break;

                case 6:
                    Debug.Log("es ist eine 6");
                    //DontDestroyOnLoad(this.gameObject);
                    DontDestroyOnLoad(GameObject.Find("Wert6"));
                    break;

            }

        }
        /*if (this.gameObject == null)
        {
            this.gameObject = this;
        }
        else
        {
            Object.Destroy(this.gameObject);
        }*/
    }
}




