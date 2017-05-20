using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseTakotakSoloGame : MonoBehaviour {

	//Load Menu on loss
    public void returnToMenu()
    {
        SceneManager.LoadScene("LossMenu", LoadSceneMode.Single);
    }
}
