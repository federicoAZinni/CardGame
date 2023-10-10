using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPhase : Phase
{
    public int TurnToEndInitPhase = 7;
    public int currentTurnInit = 0;

    public void OnClick(Interactable interactable)
    {
        
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
