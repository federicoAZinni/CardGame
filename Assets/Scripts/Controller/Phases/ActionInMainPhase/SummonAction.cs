using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class SummonAction : Action
{
    public Card card;
    public FieldSlot fieldSlot;

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
        Debug.Log("Start Summon Action");

        while (!isFinish)
        {
            if (fieldSlot != null && card != null)
            {
                isFinish = true;
                fieldSlot.SetCard(card);
                OnFinishAction?.Invoke();
                OnEndSummon();
            }
            await Task.Yield();
        }
    }

    void OnEndSummon()
    {
        Debug.Log("End Summon");
    }
}
