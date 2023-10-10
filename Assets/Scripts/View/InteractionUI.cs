using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    
    public virtual void OnClick(Interactable interactable)
    {
        GameManager.Instance.OnClick(interactable);
    }
}
