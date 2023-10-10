using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public TypeOfDeck typeOfDeck;
    public List<Card> cardsSameTypeofDeck;
    public CardData[] cardData;
    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            cardsSameTypeofDeck.Add(new Card(cardData[i]));
        }
    }

    [ContextMenu("Shuffle")]
    public void Shuffle()
    {
        List<Card> contentList = new List<Card>();

        while (cardsSameTypeofDeck.Count>0)
        {
            int random = Random.Range(0, cardsSameTypeofDeck.Count);
            contentList.Add(cardsSameTypeofDeck[random]);
            cardsSameTypeofDeck.RemoveAt(random);
        }

        foreach (Card card in contentList)
        {
            cardsSameTypeofDeck.Add(card);
        }
    }

    public Card GiveOneCard()
    {
        Card card = cardsSameTypeofDeck[0];
        cardsSameTypeofDeck.RemoveAt(0);
        return card;
    }

}
public enum TypeOfDeck
{
    Serpent, Knight
}