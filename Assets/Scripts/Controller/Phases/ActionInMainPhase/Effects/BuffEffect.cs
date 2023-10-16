using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class BuffEffect : EffectAction
{
    bool isFinish;

    public override void ActionSolve()
    {
        throw new System.NotImplementedException();
    }

    protected override void StartEffect()
    {
        Debug.Log("Start BuffEffect");
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
                OnFinishAction?.Invoke();
                OnEndEffect();
            }
            await Task.Yield();
        }
    }
}
