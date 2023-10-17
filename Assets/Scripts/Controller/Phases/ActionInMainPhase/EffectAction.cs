using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class EffectAction : Action
{
    public InteractionUI cardEffectActivate;
    public FieldSlotUI cardSelectedToDestroy;
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
        Debug.Log("END Effect");
    }

    public override void ActionSolve()
    {
        
    }
    public override void ActionCancel()
    {
        
        Debug.Log("Action Canceled");
    }
}