using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPhase : Phase
{
    public int TurnToEndInitPhase = 7;
    public int currentTurnInit = 0;

    public void OnClick(Card card)
    {
        throw new System.NotImplementedException();
    }

    public void OnClick(Deck Deck)
    {
        //DrawOneCardOfDeck(deck,Acá se puede pasar la referencia directamente desde GameManager.Instances.PlayerHand);
    }

    public void OnEnd()
    {
        Debug.Log("InitPhase End");
    }

    public void OnStart()
    {
        Debug.Log("InitPhase Start");
    }

    public void OnUpdate()
    {
        if (Input.GetMouseButtonDown(0)) currentTurnInit++;

        if (currentTurnInit == TurnToEndInitPhase) GameManager.Instance.ChangePhase(new MainPhase());
    }

    public void DrawOneCardOfDeck(Deck deck, PlayerHand playerHand)
    {
        if (currentTurnInit >= TurnToEndInitPhase) OnEnd();
        Card card = deck.GiveOneCard();
        playerHand.AddCardToHand(card);
        currentTurnInit++;
    }

  
}
