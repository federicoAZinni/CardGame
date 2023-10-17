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
    [SerializeField] Button Effect_Btn;


    private void Awake()
    {
        Battle_Btn.onClick.AddListener(() => { GameManager.Instance.StartActionBtn(fieldSlot.player,ActionSelected.Battle,"",this); }); //solo llama a la acion si es el turno
        Effect_Btn.onClick.AddListener(() => { GameManager.Instance.StartActionBtn(fieldSlot.currentCard.player, ActionSelected.Effect, fieldSlot.currentCard.effect, this); });
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
        player = fieldSlot.player;
        name_Txt.text = fieldSlot.currentCard.soulPoints.ToString();
        soulPoint_Txt.text = fieldSlot.currentCard.soulPoints.ToString();

        if (fieldSlot.currentCard.effect == EffectTypes.PermanentBuffEffect) Effect_Btn.gameObject.SetActive(false); //Muestro o saco el boton de effect para que no se ueda usar desde la mano
        else Effect_Btn.gameObject.SetActive(true);
    }

    public void RemoveFieldSlotToNull()
    {
        player = 100; // deberia ser null pero el int no puede ser null 
        name_Txt.text = "";
        soulPoint_Txt.text = "";
        //effect_Txt.text = "";
    }

    public override void SendCardToGraveyard()
    {
        GameManager.Instance.graveyards[fieldSlot.currentCard.player].AddCardToGraveyard(fieldSlot.currentCard);
        fieldSlot.RemoveCard();
        RemoveFieldSlotToNull();
    }
    public void OnClick() // pasamos el Deck o la carta por los enevetos del boton
    {
        base.OnClick(fieldSlot);
    }

}
