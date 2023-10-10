using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FieldSlot : MonoBehaviour
{
    public TypeFieldSlot typeFieldSlot;
    public bool canAttack;
    public Card currentCard;
    [SerializeField] FieldSlotUI fieldSlotUI;

    public bool SetCard(Card card)
    {
        if (currentCard != null) return false;

        currentCard = card;
        fieldSlotUI.SetFieldSlotUI();
        return true;
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
