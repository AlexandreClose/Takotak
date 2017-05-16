using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCard : MonoBehaviour {

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            if ( hit )
            {
                if (hit.transform.parent.name == "Hand")
                {
                    GameObject card = hit.transform.gameObject;

                    //check color or number or symbol of heap
                    CardProperties cardProperties = card.GetComponent<CardProperties>();

                    //get properties of the tapped card
                    int nSymbols = cardProperties.nSymbol;
                    int nColor = cardProperties.nColor;
                    int nSymbolType = cardProperties.nSymbolType;

                    //get properties of the heap card
                    CardProperties heapCardProperties = GameObject.Find("Heap").GetComponentsInChildren<CardProperties>()[0];
                    int nSymbolsHeap = heapCardProperties.nSymbol;
                    int nColorHeap = heapCardProperties.nColor;
                    int nSymbolTypeHeap = heapCardProperties.nSymbolType;


                    if (nSymbols == nSymbolsHeap ||
                        nColor == nColorHeap ||
                        nSymbolType == nSymbolTypeHeap)
                    {
                        Vector3 transformHandCard = new Vector3();
                        transformHandCard = card.transform.position;

                        

                        //Change card in heap
                        GameObject.Find("Heap").GetComponent<CardHeap>().changeCard( card.GetComponent<CardProperties>() );

                        //drop targeted card
                        Destroy(card);

                        //Draw new card in hand. 
                        GameObject.Find("Hand").GetComponent<CardHand>().drawCard(transformHandCard);


                    }
                    else
                    {
                    }

                }
            }
        }
    }
}
