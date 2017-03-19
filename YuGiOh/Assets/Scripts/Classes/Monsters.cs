using UnityEngine;
using System.Collections;
using System;

public class Monsters : Cards
{
    bool _attacDefencState;
    int _attackPoints;
    int _defencePoints;
    int _rank;
    string _type;
    string _attribute;
    string _race;
    public int DefencePoints
    {
        get
        {
            return _defencePoints;
        }

        set
        {
            _defencePoints = value;
        }
    }

    public int AttackPoints
    {
        get
        {
            return _attackPoints;
        }

        set
        {
            _attackPoints = value;
        }
    }

    public bool AttacDefencState
    {
        get
        {
            return _attacDefencState;
        }

        set
        {
            _attacDefencState = value;
        }
    }

    public int Rank
    {
        get
        {
            return _rank;
        }

        set
        {
            _rank = value;
        }
    }

    public string Type
    {
        get
        {
            return _type;
        }

        set
        {
            _type = value;
        }
    }

    public string Attribute
    {
        get
        {
            return _attribute;
        }

        set
        {
            _attribute = value;
        }
    }

    public string Race
    {
        get
        {
            return _race;
        }

        set
        {
            _race = value;
        }
    }

    public Monsters(string name,string Desc,Sprite image)
    {
        CardName = name;
        CardDesc = Desc;
        CardImage = image;
    }

    public Monsters()
    {
        
    }
    public Monsters(Monsters m)
    {
        this.AttackPoints = m.AttackPoints;
        this.ID=m.ID;
        this.CardImage = m.CardImage;
        this.CardName=m.CardName ;
        this.CardDesc=m.CardDesc ;
        this.Rank=m.Rank ;
        this.Attribute=m.Attribute;
        this.Race= m.Race ;
        this.DefencePoints=m.DefencePoints ;
    }
    public override void destroyCard()
    {
        
    }
    public void Attack(Monsters mon, Player attk, Player def) // if a card is attacked we also need to know the owners of the attacking and the attacked monsters
    {
        if (mon.AttacDefencState == true)// If The monster attacked is on attack state
        {
            if (this.AttackPoints == mon.AttackPoints)
            {
                mon.destroyCard();
                this.destroyCard();


            }
            else if (this.AttackPoints > mon.AttackPoints)
            {
                mon.destroyCard();
                def.LifePoints -= (this.AttackPoints - mon.AttackPoints);

            }
            else
            {
                this.destroyCard();
                attk.LifePoints = attk.LifePoints - (mon.AttackPoints - this.AttackPoints);

            }

        }
        else                        // If The monster attacked is on defense state
        {
            if (this.AttackPoints == mon.DefencePoints)
            {
                //do nothing
            }
            else if (this.AttackPoints > mon.DefencePoints)
            {
                mon.destroyCard();
            }
            else if (this.AttackPoints < mon.DefencePoints)
            {
                attk.LifePoints = attk.LifePoints - (mon.DefencePoints - this.AttackPoints);
            }


        }

    }
    public void Attack(Player ply)// when Player is attacked directly(THERE IS MUST BE NO MONSTERS IN HIS FIELD)
    {
        ply.LifePoints -= this.AttackPoints;

    }
}
