using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class ImageScript : MonoBehaviour,IPointerEnterHandler {
    public GameObject card;
    //public Image card2;
    public Cards c;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.tag == "Monster")
        {
            c = new Monsters(card.name, "this monster attacks is dangrous", card.GetComponent<SpriteRenderer>().sprite);
        }
        else
        {

            c = new Spells(card.name, "Casting a Spell", card.GetComponent<Image>().sprite);
        }
    }

    
}
