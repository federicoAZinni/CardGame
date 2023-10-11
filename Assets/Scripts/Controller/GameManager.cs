using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Singlenton
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(gameObject);
    }
    #endregion

    public CardData[] listaCardData; // no ma pa probar cositas 
    public List<Card> cards;

    public static int currentPlayer;

    Phase currentPhase;

    public static System.Action<bool> OnActionStart;

    private void Start()
    {
        foreach (CardData cardData in listaCardData)// pa probar no mas
        {
            cards.Add(new Card(cardData));
        }

        ChangePhase(new InitPhase());
    }

    void Update()
    {
        currentPhase.OnUpdate();
    }

    public void ChangePhase(Phase newPhase)
    {
        if(currentPhase!=null) currentPhase.OnEnd();
        currentPhase = newPhase;
        currentPhase.OnStart();
    }

    public void OnClick(Interactable interactable)
    {
        currentPhase.OnClick(interactable);
    }

    public void ChangeCurrentPlayer()
    {
        if (currentPlayer == 0) currentPlayer = 1;
        else currentPlayer = 0;
    }

    public void SendToGraveyard(Graveyard graveyardPlayer, Card card)
    {

    }
    public void SendToHand(PlayerHand playerHand)
    {

    }

    //------------------------StartAction (Los llaman los botenes de las cartas)---------------------------------------------
    public void StartBattleBtn()
    {
        if (currentPhase.GetType().IsEquivalentTo(typeof(MainPhase)))
        {
            MainPhase phase = (MainPhase)currentPhase;
            phase.ActiveBattleAction();
            OnActionStart?.Invoke(true);
        }
    }
    public void StartEffectBtn()
    {
        if (currentPhase.GetType().IsEquivalentTo(typeof(MainPhase)))
        {
            MainPhase phase = (MainPhase)currentPhase;
            phase.ActiveEffectAction();
            OnActionStart?.Invoke(true);
        }
    }
    public void StartSummonBtn()
    {
        if (currentPhase.GetType().IsEquivalentTo(typeof(MainPhase)))
        {
            MainPhase phase = (MainPhase)currentPhase;
            phase.ActiveSummonAction();
            OnActionStart?.Invoke(true);
        }
    }
    //----------------------------------------------------------------------------------------------------------------------


    public void TurnOver()
    {
        ChangeCurrentPlayer();
        ChangePhase(new DrawPhase());
    }

    public Card ReturnNewCard()// solo para testear
    {
        return new Card(listaCardData[Random.Range(0, listaCardData.Length)]);
    }
}
