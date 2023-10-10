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


    private void Start()//  para testear no mas 
    {
        SetCard(GameManager.Instance.ReturnNewCard());
    }


    public void OnClick() // pasamos el Deck o la carta por los enevetos del boton
    {
        base.OnClick(currentCard);
    }

    public void ShowMenu()
    {

    }

    public void HideMenu()
    {

    }

    public void SetCard(Card card)
    {
        name_Txt.text = card.soulPoints.ToString();
        soulPoint_Txt.text = card.soulPoints.ToString();

        currentCard = card;
    }
}
