using UnityEngine;
using Vuforia;
using System.Collections;
public class MyPrefabInstantiator : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    public Transform myModelPrefab;
    public static int currentNumber;
    public static bool currentNumberbool;
    //public static MyPrefabInstantiator instance;

    // Use this for initialization
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void OnTrackableStateChanged(
      TrackableBehaviour.Status previousStatus,
      TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
    }
    public void OnTrackingFound()
    {
        if (myModelPrefab != null)
        {
            Debug.Log("erkannt");
            Transform myModelTrf = GameObject.Instantiate(myModelPrefab) as Transform;
            myModelTrf.parent = mTrackableBehaviour.transform;
            myModelTrf.localPosition = new Vector3(0f, 0f, 0f);
            myModelTrf.localRotation = Quaternion.identity;
            myModelTrf.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            myModelTrf.gameObject.SetActive(true);
            currentNumber = GetComponent<TextScriptVuforia>().diceNumber;
            Debug.Log(currentNumber);

            if (currentNumber != 0)
            {
                currentNumberbool = true;
                //Wert.Vermittler();
                //SwitchCanvas.ChangingCanvas();
                LoadScene2.SceneLoader2(0);
            } 
            
            //SwitchCanvas.instance.CanvasSwitch();
            //SwitchCanvas.instance.CanvasSwitch();


        }

        /*if (myModelTrf.gameObject.SetActive(true))
        {
            currentNumberbool = true;
            currentNumber = GetComponent<TextScript>().diceNumber;
            Debug.Log(currentNumber);
        }*/
    }
    
}
