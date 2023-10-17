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
    public override void ActionCancel()
    {
        isFinish = true;
        Debug.Log("Action Canceled");
    }
    async void Summon()
    {
        Debug.Log("Start Summon Action");

        while (!isFinish)
        {
            if (fieldSlot != null && card != null)
            {
                if (fieldSlot.player == card.player) 
                {
                    if (!fieldSlot.isOcuppied)
                    {
                        isFinish = true;
                        fieldSlot.SetCard(card);
                        GameManager.Instance.players[card.player].RemoveCardToHand(card); // saco la carta de la mano
                        OnFinishAction?.Invoke();
                        OnEndSummon();
                    }
                    else Debug.Log("El fieldSlot seleccionado está acupado"); 
                }
                else Debug.Log("El fieldSlot seleccionado es del otro player"); 
            }    
            await Task.Yield();
        }
    }

    void OnEndSummon()
    {
        Debug.Log("End Summon");
    }
}
