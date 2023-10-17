using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class BattleAction : Action
{
    public FieldSlot fieldSlotCard1;
    public FieldSlot fieldSlotCard2;

    bool isFinish;
    public override void ActionActivation()
    {
        Battle();
    }

    public override void ActionCancel()
    {
        isFinish = true;
        Debug.Log("Action Canceled");
    }

    public override void ActionSolve()
    {
        Debug.Log("Card 1 " + fieldSlotCard1.currentCard.soulPoints + "Card 2 " + fieldSlotCard2.currentCard.soulPoints);

        if (fieldSlotCard1.currentCard.soulPoints > fieldSlotCard2.currentCard.soulPoints) fieldSlotCard2.fieldSlotUI.SendCardToGraveyard(); // gana card1
        else if (fieldSlotCard1.currentCard.soulPoints < fieldSlotCard2.currentCard.soulPoints) fieldSlotCard1.fieldSlotUI.SendCardToGraveyard(); // gana card2
        else { fieldSlotCard1.fieldSlotUI.SendCardToGraveyard(); fieldSlotCard2.fieldSlotUI.SendCardToGraveyard(); }// empate

        OnEndBattle();
    }

    async void Battle()
    {
        Debug.Log("Start Battle of BattleAction");

        while (!isFinish)
        {
            if (fieldSlotCard1 != null && fieldSlotCard2 != null)
            {
                if (fieldSlotCard1.player != fieldSlotCard2.player)
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
