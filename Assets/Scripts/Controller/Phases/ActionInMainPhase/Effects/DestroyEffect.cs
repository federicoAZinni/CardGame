using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class DestroyEffect : EffectAction
{
    bool isFinish;

    public override void ActionSolve() //lo llama el chain cuando se ejecuta la lista de actiones guardadas
    {
        cardEffectActivate.SendCardToGraveyard();
        cardSelectedToDestroy.SendCardToGraveyard();
    }

    protected override void StartEffect()
    {
        Debug.Log("Start DestroyEffect");
        Effect();
    }


    async void Effect()
    {
        while (!isFinish)
        {
            if (cardSelectedToDestroy!=null)
            {
                isFinish = true;
                ChainManager.Instances.AddActionToChain(this);
                OnFinishAction?.Invoke();
                OnEndEffect();
            }
            await Task.Yield();
        }
    }
}
