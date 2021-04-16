using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene2 : MonoBehaviour
{
    public MyPrefabInstantiator MyPrefabInstantiator;
    public bool finalCheck;
    //public int finalNumber;


    public static void SceneLoader2(int SceneIndex)
    {
        //finalCheck = GameObject.Find("ImageTareget6").GetComponent<MyPrefabInstantiator>().currentNumberbool;
        //finalNumber = GameObject.Find("ImageTareget6").GetComponent<MyPrefabInstantiator>().currentNumber;
        if (MyPrefabInstantiator.currentNumberbool == true)
        {
            SceneManager.LoadScene(SceneIndex);
        }
        
    }
    /*public void Awake()
   {
        finalCheck = GameObject.Find("ImageTareget1").GetComponent<MyPrefabInstantiator>().currentNumberbool;
        if (MyPrefabInstantiator.currentNumberbool == true)
        {
            
        }

        /*MyPrefabInstantiator Zahl1 = Sphere1.GetComponent<MyPrefabInstantiator>().currentNumber;
        GameObject Sphere2 = GameObject.Find("Sphere 2");
        MyPrefabInstantiator Zahl2 = Sphere2.GetComponent<MyPrefabInstantiator>();
        Zahl2.currentNumber = 2;
        GameObject Sphere3 = GameObject.Find("Sphere 3");
        MyPrefabInstantiator Zahl3 = Sphere2.GetComponent<MyPrefabInstantiator>();
        Zahl3.currentNumber = 2;
        GameObject Sphere4 = GameObject.Find("Sphere 4");
        MyPrefabInstantiator Zahl4 = Sphere2.GetComponent<MyPrefabInstantiator>();
        Zahl4.currentNumber = 2;
        GameObject Sphere5 = GameObject.Find("Sphere 5");
        MyPrefabInstantiator Zahl5 = Sphere2.GetComponent<MyPrefabInstantiator>();
        Zahl5.currentNumber = 2;
        GameObject Sphere6 = GameObject.Find("Sphere 6");
        MyPrefabInstantiator Zahl6 = Sphere2.GetComponent<MyPrefabInstantiator>();
        Zahl6.currentNumber = 2;
    }*/
}
