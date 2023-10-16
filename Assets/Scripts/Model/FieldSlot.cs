using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FieldSlot : MonoBehaviour, Interactable
{
    public TypeFieldSlot typeFieldSlot;
    public bool canAttack;
    public Card currentCard;
    public bool isOcuppied;
    public int player;
    [SerializeField] FieldSlotUI fieldSlotUI;

    public int Player => player;

    public void SetCard(Card card)
    {
        isOcuppied = true;
        currentCard = card;
        fieldSlotUI.SetFieldSlotUI();
    }

    public void RemoveCard()
    {
        isOcuppied = false;
        currentCard = null;
        fieldSlotUI.RemoveFieldSlotToNull();
    }

    public void ResetAttack()
    {
        canAttack = true;
    }
    public void SendCardToGraveyard()
    {
        GameManager.Instance.graveyards[currentCard.player].AddCardToGraveyard(currentCard);
        RemoveCard();
    }
}
public enum TypeFieldSlot
{
    Trap, Criature, Exile
}
