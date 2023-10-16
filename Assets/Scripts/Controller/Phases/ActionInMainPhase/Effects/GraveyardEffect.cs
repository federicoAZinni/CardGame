using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class GraveyardEffect : EffectAction
{
    bool isFinish;

    public override void ActionSolve()
    {
        Debug.Log("Solved GraveYard Effect");
        OnFinishAction?.Invoke();
    }

    protected override void StartEffect()
    {
        Debug.Log("Start GraveyardEffect");
        Effect();
    }


    async void Effect()
    {
        int countClick = 0;
        while (!isFinish)
        {
            if (Input.GetMouseButtonDown(0))
            {
                countClick++;
            }
            if (countClick > 5)
            {
                isFinish = true;
                ChainManager.Instances.AddActionToChain(this);
                OnFinishAction?.Invoke();
                Debug.Log("Add Action to Chain");
            }
            await Task.Yield();
        }
    }
}
