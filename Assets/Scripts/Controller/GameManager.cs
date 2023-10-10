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

    public int currentPlayer;

    Phase currentPhase;

    private void Start()
    {

        foreach (CardData cardData in listaCardData)
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

    public void StartBattleBtn()
    {
        if (currentPhase.GetType().IsEquivalentTo(typeof(MainPhase)))
        {
            MainPhase phase = (MainPhase)currentPhase;
            phase.ActiveBattleAction();
        }
    }
    public void StartEffectBtn()
    {
        
    }
    public void StartSummonBtn()
    {
        if (currentPhase.GetType().IsEquivalentTo(typeof(MainPhase)))
        {
            MainPhase phase = (MainPhase)currentPhase;
            phase.ActiveSummonAction();
        }
    }

    public Card ReturnNewCard()// solo para testear
    {
        return new Card(listaCardData[Random.Range(0, listaCardData.Length)]);
    }
}
