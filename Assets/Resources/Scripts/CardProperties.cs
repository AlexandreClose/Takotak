using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardProperties : MonoBehaviour {

    public int _nSymbolType;
    public int _nColor;
    public int _nSymbol;

    //Properties
    public int nSymbolType
    {
       get
        {
            return this._nSymbolType;
        }
        set
        {
            this._nSymbolType = value;
        }
    }

    public int nColor
    {
        get
        {
            return this._nColor;
        }
        set
        {
            this._nColor = value;
        }
    }

    public int nSymbol
    {
        get
        {
            return this._nSymbol;
        }
        set
        {
            this._nSymbol = value;
        }
    }
}
