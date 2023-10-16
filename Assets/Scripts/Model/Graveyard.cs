using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graveyard : MonoBehaviour
{
    public List<Card> graveyardList;

    public void AddCardToGraveyard(Card card)
    {
        graveyardList.Add(card);
    }
}
