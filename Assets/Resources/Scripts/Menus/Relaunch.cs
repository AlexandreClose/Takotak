using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Relaunch : MonoBehaviour {

    public void loadScene()
    {
        SceneManager.LoadScene("TakotakSoloGame", LoadSceneMode.Single);
    }
}
