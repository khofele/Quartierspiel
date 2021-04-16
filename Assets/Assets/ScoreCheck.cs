using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreCheck : MonoBehaviour
{
  
   /* public int goldRessource = GameManager.instance.goldRessource;
    public int umweltRessource = GameManager.instance.umweltRessource;
    public int zufriedenheitRessource = GameManager.instance.zufriedenheitRessource; */

    public int Baukosten;
    public int EreignisGold;
    public int EreignisÖko;
    public int EreignisZufriedenheit;




    // Start is called before the first frame update
    public void EreignisundGebäudeVerrechnung()

    {
        GameManager.instance.goldRessource += EreignisGold + Baukosten;
        GameManager.instance.umweltRessource += EreignisÖko;
        GameManager.instance.zufriedenheitRessource += EreignisZufriedenheit;
        Debug.Log(GameManager.instance.goldRessource);
        Debug.Log(GameManager.instance.umweltRessource);
        Debug.Log(GameManager.instance.zufriedenheitRessource);

    }


}