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
        throw new System.NotImplementedException();
    }

    public void OnStart()
    {
        throw new System.NotImplementedException();
    }

    public void OnUpdate()
    {
        throw new System.NotImplementedException();
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