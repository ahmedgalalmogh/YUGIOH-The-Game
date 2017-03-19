using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Deck  {

    public Dictionary<string, Cards> PlayerDeck;  //int=id ,, Cards=obje
    public int size;
    public Deck()
    {
        PlayerDeck = new Dictionary<string, Cards>();
        size = 0;
    }
    
}
