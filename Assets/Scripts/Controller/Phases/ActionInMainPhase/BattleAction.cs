using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class BattleAction : Action
{
    public Card card1;
    public Card card2;

    bool isFinish;
    public override void ActionActivation()
    {
        Battle();
    }

    public override void ActionSolve()
    {
        Debug.Log("Card 1 " + card1.soulPoints + "Card 2 " + card2.soulPoints);
        OnEndBattle();
    }

    async void Battle()
    {
        Debug.Log("Start Battle of BattleAction");

        while (!isFinish)
        {
            if (card1 != null && card2 != null)
            {
                isFinish = true;
                ChainManager.Instances.AddActionToChain(this);
                OnFinishAction?.Invoke();
                Debug.Log("Add Action to Chain");
            }
            await Task.Yield();
        }
    }

    void OnEndBattle()
    {
        Debug.Log("End Battle");
    }
}
