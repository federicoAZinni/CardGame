using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public abstract class Action
{
    public abstract void ActionActivation();
    public abstract void ActionSolve();
    public abstract void ActionCancel();



    public System.Action OnFinishAction;
}