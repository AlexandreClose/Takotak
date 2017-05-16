using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour {

    public GameObject prefabHearth;

    private Transform transformParent;
	// Use this for initialization
	void Start () {
        transformParent = transform;
    }

    public void addLife()
    {
        GameObject hearth = GameObject.Instantiate(prefabHearth);
        hearth.transform.SetParent(transformParent, false);
        transformParent = hearth.transform;
    }

    public void dropLife()
    {
        transformParent = transformParent.parent.transform;
        DestroyImmediate(transformParent.GetChild(0).gameObject);
    }

}
