using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Live : MonoBehaviour {

    public int nbLivesBegin = 3;
    private int nCurrentLives;

    // Use this for initialization
    void Start () {
        nCurrentLives = nbLivesBegin;

        for ( int i = 1; i<= nbLivesBegin; i++)
        {
            GameObject.Find("LifeBar").GetComponent<LifeBar>().addLife();
        }
	}

    public void dropLife()
    {
        GameObject.Find("LifeBar").GetComponent<LifeBar>().dropLife();
        nCurrentLives--;
        if ( nCurrentLives == 0 )
        {
            GameObject.Find("GameStateManager").GetComponent<LoseTakotakSoloGame>().returnToMenu();
        }
    }
}
