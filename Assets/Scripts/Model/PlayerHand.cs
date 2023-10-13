using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public List<Card> cardsInHand;
    [SerializeField] List<CardUI> cardUISlots;

    private void Awake()
    {
        cardsInHand = new List<Card>();

        foreach (Transform item in transform) // solo pa probar lleno la lista con los hijos
        {
            cardUISlots.Add(item.GetComponent<CardUI>());
        }
    }

    public void AddCardToHand(Card card)
    {
        cardsInHand.Add(card);
        ShowNewCardInHand(card);
    }
    public void RemoveCardToHand(Card card)
    {
        cardsInHand.Remove(card);
        HideCardSlotInHand(card);
    }

    void ShowNewCardInHand(Card card)
    {
        foreach (CardUI cardUI in cardUISlots)
        {
            if (!cardUI.gameObject.activeSelf)
            {
                cardUI.SetCard(card);
                cardUI.gameObject.SetActive(true);
                break;
            }   
        }
    }
    void HideCardSlotInHand(Card card)
    {
        foreach (CardUI cardUI in cardUISlots)
        {
            if (card == cardUI.currentCard)
            {
                cardUI.RemoveCardToNull();
                cardUI.gameObject.SetActive(false);
                break;
            }   
        }
    }
}
