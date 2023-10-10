using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public List<Card> cardsInHand;

    private void Awake()
    {
        cardsInHand = new List<Card>();
    }

    public void AddCardToHand(Card card)
    {
        cardsInHand.Add(card);
    }
    public void RemoveCardToHand(Card card)
    {
        cardsInHand.Remove(card);
    }
}
