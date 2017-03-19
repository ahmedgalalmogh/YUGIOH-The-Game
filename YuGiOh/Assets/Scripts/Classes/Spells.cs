using UnityEngine;
using System.Collections;
using System;

public class Spells : Cards {

    string type;
    public Spells(string name,string Desc,Sprite image)
    {
        CardName = name;
        CardDesc = Desc;
        CardImage = image;
    }
    public Spells()
    {

    }
    public Spells(Spells s)
    {
        this.CardName = s.CardName;
        this.CardDesc = s.CardDesc;
        this.CardImage = s.CardImage;
    }
    public override void destroyCard()
    {
        
    }

}
//string function = "void add (int x , int y) {return x+y ;}"
