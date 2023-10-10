using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    
    public virtual void OnClick(Card Card)
    {
        GameManager.Instance.OnClick(Card);
    }
    public virtual void OnClick(Deck deck)
    {
        GameManager.Instance.OnClick(deck);
    }
}
