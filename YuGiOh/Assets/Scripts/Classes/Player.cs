using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player {

    Deck myDeck;
    List<Cards> randomOrderPlayingCard;
    int lifePoints;
    string playerName;
    List<Cards> graveYard;
    public Player()
    {
        myDeck = new Deck();
        randomOrderPlayingCard = new List<Cards>();
        graveYard = new List<Cards>();
        lifePoints = 8000;
        
    }
    public Deck MyDeck
    {
        get
        {
            return myDeck;
        }

        set
        {
            myDeck = value;
        }
    }

    public List<Cards> RandomOrderPlayingCard
    {
        get
        {
            return randomOrderPlayingCard;
        }

        set
        {
            RandomOrderPlayingCard = value;
        }
    }

    public int LifePoints
    {
        get
        {
            return LifePoints;
        }

        set
        {
            LifePoints = value;
        }
    }

    public string PlayerName
    {
        get
        {
            return PlayerName;
        }

        set
        {
            PlayerName = value;
        }
    }

    public List<Cards> GraveYard
    {
        get
        {
            return GraveYard;
        }

        set
        {
            GraveYard = value;
        }
    }

    public void DrawCard()
    {

    }
    public void DeckShuffle()
    {

    }

}
