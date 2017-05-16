using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHeap : MonoBehaviour {

    //Position de la carte de la pile
    private Vector3 heapCard = new Vector3(0.0f, 2.8f, 0.0f);

    // Use this for initialization
    void Start()
    {
        GameObject card = CardGenerator.generateCard();
        Transform tr = card.GetComponent<Transform>();
        tr.position = heapCard;
        tr.Rotate(0, 0, 90);
        card.transform.parent = this.transform;
    }

    public void changeCard ( CardProperties properties )
    {

        //delete previous card from heap
        Destroy(transform.GetChild(0).gameObject);

        //put new card in heap
        GameObject card = CardGenerator.generateCardWithProperties( properties);
        card.transform.parent = this.transform;
        card.transform.position = heapCard;
        card.transform.Rotate(0, 0, 90);
               
    }
}
