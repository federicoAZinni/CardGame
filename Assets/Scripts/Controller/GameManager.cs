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
    public PlayerHand[] players; // no ma pa probar cositas 
    

    public static int currentPlayer;

    Phase currentPhase;

    public static System.Action<bool> OnActionStart;

    private void Start()
    {
        foreach (CardData cardData in listaCardData)// pa probar no mas
        {
            cards.Add(new Card(cardData));
        }

        for (int k = 0; k < players.Length; k++)// pa probar no mas
        {
            for (int i = 0; i < cards.Count; i++)
            {
                Card card = ReturnNewCard();
                card.player = k;
                players[k].AddCardToHand(card);
            }
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
    public void StartActionBtn(int player, ActionSelected action)
    {
        if(player != currentPlayer) { Debug.Log("No es tu turno"); return; }

        if (currentPhase.GetType().IsEquivalentTo(typeof(MainPhase)))
        {
            MainPhase phase = (MainPhase)currentPhase;
            switch (action)
            {
                case ActionSelected.Battle:
                    phase.ActiveBattleAction();
                    break;
                case ActionSelected.Effect:
                    phase.ActiveEffectAction();
                    break;
                case ActionSelected.Summon:
                    phase.ActiveSummonAction();
                    break;
                case ActionSelected.Nothing:
                    break;
                default:
                    break;
            }
            
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
