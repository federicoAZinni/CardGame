using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FieldSlotUI : InteractionUI
{
    public FieldSlot fieldSlot;

    [Header("--- All UI object Refs---")]
    [SerializeField] TextMeshProUGUI name_Txt;
    [SerializeField] TextMeshProUGUI soulPoint_Txt;
    [SerializeField] GameObject menuPanel;

    [Header("--- Menu Button Refs---")]
    [SerializeField] Button Battle_Btn;


    private void Awake()
    {
        Battle_Btn.onClick.AddListener(() => { GameManager.Instance.StartActionBtn(fieldSlot.player,ActionSelected.Battle,"",fieldSlot); }); //solo llama a la acion si es el turno
    }
    public void ShowMenu()
    {
        if (GameManager.currentPlayer != fieldSlot.player) return; //solo se abre el menu si es el turno
        if (!fieldSlot.isOcuppied) return;
        if (base.canShowMenu) return;
        menuPanel.SetActive(true);
    }

    public void HideMenu()
    {
        menuPanel.SetActive(false);
    }


    public void SetFieldSlotUI()
    {
        name_Txt.text = fieldSlot.currentCard.soulPoints.ToString();
        soulPoint_Txt.text = fieldSlot.currentCard.soulPoints.ToString();
    }

    public void RemoveFieldSlotToNull()
    {
        name_Txt.text = "";
        soulPoint_Txt.text = "";
        //effect_Txt.text = "";
    }

    public void OnClick() // pasamos el Deck o la carta por los enevetos del boton
    {
        
        base.OnClick(fieldSlot);
    }

}
