using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class BattleAction : Action
{
    public FieldSlot card1;
    public FieldSlot card2;

    bool isFinish;
    public override void ActionActivation()
    {
        Battle();
    }

    public override void ActionSolve()
    {
        Debug.Log("Card 1 " + card1.currentCard.soulPoints + "Card 2 " + card2.currentCard.soulPoints);

        if (card1.currentCard.soulPoints > card2.currentCard.soulPoints) card2.SendCardToGraveyard(); // gana card1
        else if (card1.currentCard.soulPoints < card2.currentCard.soulPoints) card1.SendCardToGraveyard(); // gana card2
        else { card1.SendCardToGraveyard(); card2.SendCardToGraveyard(); }// empate

        OnEndBattle();
    }

    async void Battle()
    {
        Debug.Log("Start Battle of BattleAction");

        while (!isFinish)
        {
            if (card1 != null && card2 != null)
            {
                if (card1.player != card2.player)
                {
                    isFinish = true;
                    ChainManager.Instances.AddActionToChain(this);
                    OnFinishAction?.Invoke();
                    Debug.Log("Add Action to Chain");
                }
            }
            await Task.Yield();
        }
    }

    void OnEndBattle()
    {
        Debug.Log("End Battle");
    }
}
