using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPhase : Phase
{
    public DrawMode currentDrawMode;

    public void OnClick(Interactable interactable)
    {
        throw new System.NotImplementedException();
    }
    public void OnEnd()
    {
        Debug.Log("End Draw Phase");
    }

    public void OnStart()
    {
        Debug.Log("Start Draw Phase Player: " + GameManager.currentPlayer);
    }

    public void OnUpdate()
    {
        Debug.Log("Update Draw Phase");
        if (Input.GetMouseButtonDown(0)) GameManager.Instance.ChangePhase(new MainPhase());
    }


    public void DrawModeLimited()
    {

    }
    public void DrawModeUnLimited()
    {

    }

   
}

public enum DrawMode
{
    Limited, Unlimited
}