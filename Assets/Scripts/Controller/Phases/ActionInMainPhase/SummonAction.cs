using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonAction : Action
{
    public override void ActionActivation()
    {
        StartEffect();
    }

    protected virtual void StartEffect()
    {
        Debug.Log("Start Effect");
    }

    protected virtual void OnEndEffect()
    {
        Debug.Log("End Effect");
        OnFinishAction?.Invoke();
    }

    public override void ActionSolve()
    {
        throw new System.NotImplementedException();
    }
}
