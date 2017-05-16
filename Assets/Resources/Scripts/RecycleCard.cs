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
        Debug.Log("HEAP nb sym" + nSymbolsHeap + "  n color" + nColorHeap + " nSymboltype" + nSymbolTypeHeap);
        int i = 1;
        foreach (CardProperties properties in handCardProperties)
        {
            int nSymbolsHand = properties.nSymbol;
            int nColorHand = properties.nColor;
            int nSymbolTypeHand = properties.nSymbolType;
            Debug.Log("CARTE "+i+" nb sym" + nSymbolsHand + "  n color" + nColorHand + " nSymboltype" + nSymbolTypeHand);
            if (nSymbolsHand == nSymbolsHeap || nColorHand == nColorHeap || nSymbolTypeHand == nSymbolTypeHeap)
            {
                ispossible = true;
            }

            i++;   
        }

        if (!ispossible)
        {
            GameObject.Find("Hand").GetComponent<CardHand>().dropCards();
            GameObject.Find("Hand").GetComponent<CardHand>().drawCards();
        }
    }
}
