using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour {


    public static GameObject prefabCard ;
    public static GameObject prefabSymbol ;

    public static int nMaxSymbol = 4;

    //distance entre les symboles 
    public static float dYSymbols = 1.0f;

    //Dictionary assets for card Symbols
    private static List<Sprite> listSymbols;

    //Dictionary colors for Symbols colors
    private static List<Color> listColors;

	// Use this for initialization
	void Awake () {

        prefabCard = Resources.Load("Prefabs/Card", typeof(GameObject) ) as GameObject;
        prefabSymbol = Resources.Load("Prefabs/Symbol", typeof(GameObject) ) as GameObject;

        //Initialize dictonaries
        listSymbols = new List<Sprite>();
        listColors = new List<Color>();

        //Initialize dictionaries of Sprites for symbols
        SpriteRenderer[] listSpritesSymbols = GameObject.Find("CardSymbols").GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer spriteRenderer in listSpritesSymbols)
        {
            listSymbols.Add(spriteRenderer.sprite);
        }

        //Initialize dictionaries of Colors for symbols
        listColors.Add(Color.blue);
        listColors.Add(Color.yellow);
        listColors.Add(Color.red);
        listColors.Add(Color.cyan);
        listColors.Add(Color.magenta);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static GameObject generateCard()
    {
        

        //generate random numbers for type, color and symbol.
        int nColor = (int)Random.Range( 1 , listColors.Count+1 );
        int nSymbol = (int)Random.Range( 1, nMaxSymbol+1);
        int nSymbolType = (int)Random.Range( 1, listSymbols.Count+1 );

        //Instantiate  prefab card
        GameObject card = (GameObject)Instantiate(prefabCard );
        

        //Instantite prefab symbol for each nb symbol
        for ( int i = 1; i<= nSymbol; i++)
        {
            GameObject symbol = (GameObject)Instantiate(prefabSymbol);
            symbol.transform.parent = card.transform;
            symbol.transform.position = card.transform.position;
            symbol.GetComponent<SpriteRenderer>().sprite = listSymbols[nSymbolType-1];
            symbol.GetComponent<SpriteRenderer>().color = listColors[nColor-1];
            
        }
       
        //set properties of this card to allow computation for the gameplay
        CardProperties cardProperties = card.GetComponent<CardProperties>();
        cardProperties.nColor = nColor;
        cardProperties.nSymbol = nSymbol;
        cardProperties.nSymbolType = nSymbolType;

        //Transform symbols on card, depend on the number of symb.
        dispatchSymbols(card);

        return card;
    }

    public static GameObject generateCardWithProperties( CardProperties properties )
    {
        //Instantiate  prefab card
        GameObject card = (GameObject)Instantiate(prefabCard);


        //Instantite prefab symbol for each nb symbol
        for (int i = 1; i <= properties.nSymbol; i++)
        {
            GameObject symbol = (GameObject)Instantiate(prefabSymbol);
            symbol.transform.parent = card.transform;
            symbol.transform.position = card.transform.position;
            symbol.GetComponent<SpriteRenderer>().sprite = listSymbols[properties.nSymbolType-1];
            symbol.GetComponent<SpriteRenderer>().color = listColors[properties.nColor-1];

        }

        //set properties of this card to allow computation for the gameplay
        CardProperties cardProperties = card.GetComponent<CardProperties>();
        cardProperties.nColor = properties.nColor;
        cardProperties.nSymbol = properties.nSymbol;
        cardProperties.nSymbolType = properties.nSymbolType;

        //Transform symbols on card, depend on the number of symb.
        dispatchSymbols(card);

        return card;
    }

    private static void dispatchSymbols(GameObject card)
    {
        Vector3 cardPosition = card.transform.position;
        Vector3 cardScale = card.transform.localScale;

        for ( int i = 0; i<card.transform.childCount; i++)
        {
            if ( card.transform.childCount % 2 == 0)
            {
                if ( i == 0 || i == 1 )
                {
                    card.transform.GetChild(i).transform.position = new Vector3(cardPosition.x, cardPosition.y + Mathf.Floor((i + 2) / 2) * Mathf.Pow((-1), i + 1) * dYSymbols * 0.66f, 0.0f);
                }
                else
                {
                    card.transform.GetChild(i).transform.position = new Vector3(cardPosition.x, cardPosition.y + Mathf.Floor((i + 2) / 2) * Mathf.Pow((-1), i + 1) * dYSymbols, 0.0f);
                }
            }
            else
            {
                card.transform.GetChild(i).transform.position = new Vector3(cardPosition.x, cardPosition.y + Mathf.Floor((i+1)/2) * Mathf.Pow( (-1), i ) * dYSymbols, 0.0f);
            }
        }
    }
}
