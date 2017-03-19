using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class TriggerScript : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler {

    Image image;
    Text txt;
    GameObject Img, textField;
    //Transform panel;

    //public void Start()
    //{
    //    image.sprite = null;
    //    txt.text = null;
    //}
    private void Start()
    {
        Img =GameObject.FindGameObjectWithTag("ImageViewer");
        textField = GameObject.FindGameObjectWithTag("TextViewer");
        image = Img.GetComponent<Image>();
        txt = textField.GetComponent<Text>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Cards card = CardsDB.AllCardsInfo[this.GetComponent<Image>().sprite.name]; ;
        //Debug.Log(typeof());
        //panel.gameObject.SetActive(true);
         if (card.GetType()==typeof(Monsters))
        {
            Monsters monster = (Monsters)card;
            image.GetComponent<Image>().sprite = monster.CardImage;
            txt.text = monster.CardName + "\r\n" + monster.CardDesc;
        }
        else if(card.GetType() == typeof(Spells))
        {
            Spells spell = (Spells)card;
            image.GetComponent<Image>().sprite = spell.CardImage;
            txt.text = spell.CardName + "\r\n" + spell.CardDesc;
        }
         else
        {
            Traps trap = (Traps)card;
            image.GetComponent<Image>().sprite = trap.CardImage;
            txt.text = trap.CardName + "\r\n" + trap.CardDesc;

        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //panel.gameObject.SetActive(false);
        image.GetComponent<Image>().sprite = null;
        txt.text = "";
    }
}
