using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardUI : InteractionUI
{
    public Card currentCard;

    [Header("--- All UI object Refs---")]
    [SerializeField] TextMeshProUGUI name_Txt;
    [SerializeField] TextMeshProUGUI soulPoint_Txt;
    [SerializeField] GameObject menuPanel;

    [Header("--- Menu Button Refs---")]
    [SerializeField] Button Summon_Btn;
    private void Awake()
    {
        Summon_Btn.onClick.AddListener(() => { GameManager.Instance.StartActionBtn(currentCard.player, ActionSelected.Summon); });  //solo llama a la acion si es el turno
    }

    public void OnClick() // pasamos el Deck o la carta por los enevetos del boton
    {
        base.OnClick(currentCard);
    }
    public void ShowMenu()
    {
        if (GameManager.currentPlayer != currentCard.player) { Debug.Log("No es tu turno"); return; } //solo se abre el menu si es el turno
        if (base.canShowMenu) return;
        menuPanel.SetActive(true);
    }
    public void HideMenu()
    {
        menuPanel.SetActive(false);
    }

    public void SetCard(Card card)
    {
        name_Txt.text = card.soulPoints.ToString();
        soulPoint_Txt.text = card.soulPoints.ToString();

        currentCard = card;
    }
    public void RemoveCardToNull()
    {
        name_Txt.text = "";
        soulPoint_Txt.text = "";

        currentCard = null;
    }
}
