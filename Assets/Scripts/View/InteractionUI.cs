using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    //-------------Para que no se habra el menu del fieldslot y cardui cuando estamos con una action
    protected bool canShowMenu;
    public int player;
    private void OnEnable()
    {
        GameManager.OnActionStart += CanShowMenu;
    }
    private void OnDisable()
    {
        GameManager.OnActionStart -= CanShowMenu;
    }
    void CanShowMenu(bool can)
    {
        canShowMenu = can;
    }
    //-------------------------------------------------------------------------------------------------
    public virtual void OnClick(Interactable interactable)
    {
      GameManager.Instance.OnClick(interactable);
    }

    public virtual void SendCardToGraveyard()
    {
        
    }
}
