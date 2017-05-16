using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleCard : MonoBehaviour {

    public void checkCards()
    {
        // regenerate card when it is impossible

        CardProperties heapCardProperties = GameObject.Find("Heap").GetComponentsInChildren<CardProperties>()[0];
        int nSymbolsHeap = heapCardProperties.nSymbol;
        int nColorHeap = heapCardProperties.nColor;
        int nSymbolTypeHeap = heapCardProperties.nSymbolType;

        CardProperties[] handCardProperties = GameObject.Find("Hand").GetComponentsInChildren<CardProperties>();
        bool ispossible = false;
        foreach (CardProperties properties in handCardProperties)
        {
            int nSymbolsHand = properties.nSymbol;
            int nColorHand = properties.nColor;
            int nSymbolTypeHand = properties.nSymbolType;
            Debug.Log("CARTE : " + nSymbolsHand + " " + nColorHand + " " + nSymbolTypeHand + " ... HEAP " + nSymbolsHeap + " " + nColorHeap + " " + nSymbolTypeHeap);
            if (nSymbolsHand == nSymbolsHeap || nColorHand == nColorHeap || nSymbolTypeHand == nSymbolTypeHeap)
            {
                ispossible = true;
            }

            
        }

        if (!ispossible)
        {
            GameObject.Find("Hand").GetComponent<CardHand>().dropCards();
            GameObject.Find("Hand").GetComponent<CardHand>().drawCards();
        }
    }
}
