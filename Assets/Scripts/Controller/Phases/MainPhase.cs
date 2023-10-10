using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPhase : Phase
{

    public int countOfSummonCriatures;
    bool TrapSummoned;
    public BattleAction currentBattleAction;
    public EffectAction currentEffectAction;
    public SummonAction currentSummonAction;

    ActionSelected currentActionSelected = ActionSelected.Nothing;

    Card currentCardSeleted;


    public void OnClick(Interactable interactable)
    {
        currentCardSeleted = (Card)interactable;
    }

    public void ChangeCurrentActionSelectedToNothing()// se llama en el evento OnFinish de cada Action
    {
        currentActionSelected = ActionSelected.Nothing;
    }

    public void OnEnd()
    {
        Debug.Log("MainPhase End");
        Debug.Log("Change Phase to EndPhase");
    }

    public void OnStart()
    {
        Debug.Log("MainPhase Start");
    }

    public void OnUpdate(){
        
        switch (currentActionSelected)
        {
            case ActionSelected.Battle:  //Preparacion para iniciar la batalla
                Debug.Log("Esperando que selecione 2 card para pelear");
                if (currentBattleAction != null)
                {
                    if (currentBattleAction.card1 == null)
                    {
                        currentBattleAction.card1 = currentCardSeleted;
                        currentCardSeleted = null;
                    }
                    else
                    {
                        if (currentCardSeleted != null) currentBattleAction.card2 = currentCardSeleted;
                    }
                }
                break;
            case ActionSelected.Effect://Preparacion para iniciar la Effecto
                break;
            case ActionSelected.Summon: //Preparacion para iniciar la Summon
                break;
            case ActionSelected.Nothing:
                break;
            default:
                break;
        }
    }

    public void ActiveBattleAction() // Inicialización de una nueva Batalla
    {
        Debug.Log("Battle Action Selected");
        currentCardSeleted = null;
        currentBattleAction = new BattleAction();
        currentBattleAction.ActionActivation();
        currentBattleAction.OnFinishAction += ChangeCurrentActionSelectedToNothing;

        currentActionSelected = ActionSelected.Battle;
    }
    public void ActiveEffectAction()// Inicialización de una nueva Effect
    {
        Debug.Log("Effect Action Selected");
        currentEffectAction = new GraveyardEffect();
        currentEffectAction.ActionActivation();
        currentEffectAction.OnFinishAction += ChangeCurrentActionSelectedToNothing;

        currentActionSelected = ActionSelected.Effect;
    }
    public void ActiveSummonAction()// Inicialización de una nueva Sumoon
    {
        Debug.Log("Summon Action Selected");
        currentSummonAction = new SummonAction();

        currentActionSelected = ActionSelected.Summon;
    }

}
public enum ActionSelected
{
    Battle,Effect,Summon,Nothing
}
