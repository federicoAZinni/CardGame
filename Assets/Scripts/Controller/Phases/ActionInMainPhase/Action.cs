using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public abstract class Action
{
    public abstract void ActionActivation();
    public abstract void ActionSolve();

    public System.Action OnFinishAction;
}