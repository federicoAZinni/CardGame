using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class SummonAction : Action
{
    public Card card1;
    public Card card2;

    bool isFinish;
    public override void ActionActivation()
    {
        Summon();
    }

    public override void ActionSolve()
    {
        OnEndSummon();
    }

    async void Summon()
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

    void OnEndSummon()
    {
        Debug.Log("End Summon");
    }
}
