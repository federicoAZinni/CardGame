using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Phase 
{
    public void OnStart();
    public void OnUpdate();
    public void OnEnd();
    public void OnClick(Interactable interactable);

}
