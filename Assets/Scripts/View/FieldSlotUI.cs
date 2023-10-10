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
        Battle_Btn.onClick.AddListener(() => { GameManager.Instance.StartBattleBtn(); });
    }
    public void ShowMenu()
    {
        if(menuPanel.activeSelf) menuPanel.SetActive(false);
        else menuPanel.SetActive(true);
    }


    public void SetFieldSlotUI()
    {
        name_Txt.text = fieldSlot.currentCard.soulPoints.ToString();
        soulPoint_Txt.text = fieldSlot.currentCard.soulPoints.ToString();
    }

    public void OnClick() // pasamos el Deck o la carta por los enevetos del boton
    {
        base.OnClick(fieldSlot);
    }

}
