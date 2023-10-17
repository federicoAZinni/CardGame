using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPhase : Phase
{
    public int countOfSummonCriatures;
    bool TrapSummoned;
    BattleAction currentBattleAction;
    EffectAction currentEffectAction;
    SummonAction currentSummonAction;

    ActionSelected currentActionSelected = ActionSelected.Nothing;

    Card currentCardSeleted;
    Deck currentDeckSeleted;
    FieldSlot currentFieldSlotSeleted;
    CardUI currentCardUISelected;
    FieldSlotUI currentFieldSlotUISelected;


    public void OnClick(Interactable interactable) //Comprobamos que tipo de objecto hicimos click
    {
        if (interactable.GetType().IsEquivalentTo(typeof(Card))) { currentCardSeleted = (Card)interactable; Debug.Log("Entro card"); }
        if (interactable.GetType().IsEquivalentTo(typeof(Deck))) currentDeckSeleted = (Deck)interactable;
        if (interactable.GetType().IsEquivalentTo(typeof(FieldSlot))) { currentFieldSlotSeleted = (FieldSlot)interactable; Debug.Log("Entro fieldSlot"); }
    }

    public void CancelAction()
    {

        currentBattleAction?.ActionCancel();
        currentEffectAction?.ActionCancel();
        currentSummonAction?.ActionCancel();
        OnEndAction();
    }

    public void OnEndAction()// se llama en el evento OnFinish de cada Action
    {
        currentCardSeleted = null;
        currentDeckSeleted = null;
        currentFieldSlotSeleted = null;

        currentBattleAction = null;
        currentEffectAction = null;
        currentSummonAction = null;

        GameManager.OnActionStart?.Invoke(false); // LLamamos este evento para que los ui puedan abrir los menus nuevamente

        currentActionSelected = ActionSelected.Nothing;
    }

    public void OnEnd()
    {
        GameManager.OnActionStart?.Invoke(false); // LLamamos este evento para que los ui puedan abrir los menus nuevamente
        Debug.Log("MainPhase End");
    }

    public void OnStart()
    {
        Debug.Log("MainPhase Start");
    }

    public void OnUpdate(){
        
        switch (currentActionSelected)
        {
            case ActionSelected.Battle:  //Preparacion para iniciar la batalla
                Debug.Log("Esperando que selecione 2 cartas en el campo para pelear");
                
                if (currentFieldSlotSeleted != null && // espero la carta que va a ser atacada
                    currentFieldSlotSeleted.isOcuppied &&
                    currentFieldSlotSeleted.player != currentBattleAction.fieldSlotCard1.player) currentBattleAction.fieldSlotCard2 = currentFieldSlotSeleted;
                
                break;



            case ActionSelected.Effect://Preparacion para iniciar la Effecto
                if (currentFieldSlotSeleted != null && // espero la carta que va a ser atacada
                    currentFieldSlotSeleted.isOcuppied &&
                    currentFieldSlotSeleted.player != currentEffectAction.cardEffectActivate.player) currentEffectAction.cardSelectedToDestroy = currentFieldSlotSeleted.fieldSlotUI;
                
                break;



            case ActionSelected.Summon: //Preparacion para iniciar la Summon
                Debug.Log("Esperando card y slotfield");
                currentSummonAction.card = currentCardSeleted;
                currentSummonAction.fieldSlot = currentFieldSlotSeleted;
                break;



            case ActionSelected.Nothing:
                break;
            default:
                break;
        }
    }

    public void ActiveBattleAction(InteractionUI cardAttack) // Inicialización de una nueva Batalla
    {
        Debug.Log("Battle Action Selected");
        currentFieldSlotSeleted = null;
        currentBattleAction = new BattleAction();
        FieldSlotUI fieldSlotUI = (FieldSlotUI)cardAttack;
        currentBattleAction.fieldSlotCard1 = fieldSlotUI.fieldSlot;
        currentBattleAction.ActionActivation();
        currentBattleAction.OnFinishAction += OnEndAction;

        currentActionSelected = ActionSelected.Battle;
    }
    public void ActiveEffectAction(string effect, InteractionUI cardAttack)// Inicialización de una nueva Effect
    {
        Debug.Log("Effect Action Selected");

        switch (effect)
        {
            case EffectTypes.DestroyEffect:
                currentEffectAction = new DestroyEffect();// crear el efecto de la carta
                currentEffectAction.cardEffectActivate = cardAttack;
                break;
            case EffectTypes.GraveyardEffect:
                currentEffectAction = new GraveyardEffect(); // crear el efecto de la carta
                break;
            case EffectTypes.PermanentBuffEffect:
                currentEffectAction = new BuffEffect(); // crear el efecto de la carta
                break;
            default:
                break;
        }
        
        currentEffectAction.ActionActivation();
        currentEffectAction.OnFinishAction += OnEndAction;

        currentActionSelected = ActionSelected.Effect;
    }
    public void ActiveSummonAction()// Inicialización de una nueva Summon
    {
        Debug.Log("Summon Action Selected");
        currentFieldSlotSeleted = null;
        currentSummonAction = new SummonAction();
        currentSummonAction.ActionActivation();
        currentSummonAction.OnFinishAction += OnEndAction;

        currentActionSelected = ActionSelected.Summon;
    }

}
public enum ActionSelected
{
    Battle,Effect,Summon,Nothing
}
