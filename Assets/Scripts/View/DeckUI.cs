using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckUI : InteractionUI
{
    public Deck currentDeck;


    public void ShowMenu()
    {

    }

    public void HideMenu()
    {

    }

    public override void OnClick(Deck card) // pasamos el Deck o la carta por los enevetos del boton
    {
        base.OnClick(currentDeck);
    }
}
