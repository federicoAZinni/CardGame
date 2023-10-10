using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FieldSlot : MonoBehaviour, Interactable
{
    public TypeFieldSlot typeFieldSlot;
    public bool canAttack;
    public Card currentCard;
    [SerializeField] FieldSlotUI fieldSlotUI;

    public void SetCard(Card card)
    {
        currentCard = card;
        fieldSlotUI.SetFieldSlotUI();
    }

    public void RemoveCard()
    {
        currentCard = null;
        fieldSlotUI.SetFieldSlotUI();
    }

    public void ResetAttack()
    {
        canAttack = true;
    }
}
public enum TypeFieldSlot
{
    Trap, Criature, Exile
}
