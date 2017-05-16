using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHand : MonoBehaviour {

    public int nCardInHand;
    

    //Position de la première carte de la main
    private Vector3 firstCard = new Vector3(-3.5f, -2.0f, 0.0f);
    //distance entre les cartes
    private Vector3 dNextCard = new Vector3(3.5f, 0.0f, 0.0f);

    // Use this for initialization
    void Start () {
        drawCards();
    }

    public void drawCards()
    {
        Vector3 nextCard = new Vector3();
        nextCard = firstCard;
        for (int i = 1; i <= nCardInHand; i++)
        {
            GameObject card = CardGenerator.generateCard();
            Transform tr = card.GetComponent<Transform>();
            tr.position = nextCard;
            nextCard = nextCard + dNextCard;
            card.transform.parent = this.transform;
        }
        //check if the hand contains a possibility to play
        GameObject.Find("GameplayEngine").GetComponent<RecycleCard>().checkCards();
    }

    public void drawCard ( Vector3 cardPosition )
    {
        GameObject card = CardGenerator.generateCard();
        card.transform.position = cardPosition;
        card.transform.parent = this.transform;

        //check if the hand contains a possibility to play
        GameObject.Find("GameplayEngine").GetComponent<RecycleCard>().checkCards();
    }

    public void dropCards()
    {
        //drop the hand
        int nChild = transform.childCount;
        for (int i = 0; i < nChild; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
