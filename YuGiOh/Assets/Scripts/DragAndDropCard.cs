using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class DragAndDropCard : MonoBehaviour, IPointerClickHandler
{
    const float DefenceScaleX= 50f;
    const float DefenceScaleY = 45f;
    const float DefenceScaleZ = 65.28835f;
    const float AttackScaleX = 43f;
    const float AttackScaleY = 65.4f;
    const float AttackScaleZ = 65.28835f;
    [HideInInspector]
    public Button Attack;
    [HideInInspector]
    public Button Defence;
    [HideInInspector]
    public GameObject panel;
    [HideInInspector]
    public GameObject MonsterField;
    [HideInInspector]
    public GameObject SpecialField;
    private void Awake()
    {
        MonsterField = GameObject.FindGameObjectWithTag("MonsterCardField");
        SpecialField = GameObject.FindGameObjectWithTag("SpecialCardField");
        panel = GameObject.FindGameObjectWithTag("Panel");
        //Debug.Log("HEre");
        //Debug.Log(MonsterField.name);
        //Debug.Log(panel.tag);
    }
    private void Start()
    {

        Attack = panel.transform.GetChild(0).GetComponent<Button>();
        Defence = panel.transform.GetChild(1).GetComponent<Button>();

        //Debug.Log(panel.name);
    }
    
    private void Update()
    {
        if(panel==null)
        {
            panel = this.transform.GetChild(2).gameObject;
            Attack = panel.transform.GetChild(0).GetComponent<Button>();
            Defence = panel.transform.GetChild(1).GetComponent<Button>();
        }
        Attack.onClick.AddListener(() => {

            panel.transform.parent.SetParent(MonsterField.transform);
            panel.transform.SetParent(this.transform.parent.parent);
            this.GetComponent<RectTransform>().localScale = new Vector3(AttackScaleX, AttackScaleY, AttackScaleZ);
            panel.gameObject.SetActive(false);
            //PanelShown = false;
        });
        Defence.onClick.AddListener(() => {
            if (panel.transform.parent == this.transform)
            {
                panel.transform.SetParent(this.transform.parent.parent);
                this.GetComponent<RectTransform>().localScale = new Vector3(45f, 35f, DefenceScaleZ);
                //Debug.Log(panel.transform.parent);
                this.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 90);
                this.transform.SetParent(MonsterField.transform);

                panel.gameObject.SetActive(false);
                //PanelShown = false;
            }


        });
        HideIfClickedOutside(panel);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        //print(panel.name);

        //Debug.Log("Clicked");
        if (MonsterField.transform.childCount < 5)
        {
            //Vector3 pos = Input.mousePosition;
            Vector3 newVector = this.transform.position;
            newVector.y += 12f;

            if (panel.activeSelf == false)
            {
                panel.gameObject.SetActive(true);
            }
            panel.transform.position = newVector;
            panel.transform.SetParent(this.transform);

        }

    }

    private void HideIfClickedOutside(GameObject panel1)
    {
        if (Input.GetMouseButton(0) && panel.activeSelf && !RectTransformUtility.RectangleContainsScreenPoint(panel.GetComponent<RectTransform>(),Input.mousePosition,Camera.main) )
        {
            panel1.SetActive(false);
        }
    }

  
}
