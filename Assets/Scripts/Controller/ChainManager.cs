using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainManager : MonoBehaviour
{
    public static ChainManager Instances;

    private void Awake()
    {
        if (Instances == null) Instances = this;
        else Destroy(gameObject);
    }

    public List<Action> actionChainList = new List<Action>();

    public void AddActionToChain(Action action)
    {
        actionChainList.Add(action);
        Debug.Log("ChainList Count: " + actionChainList.Count);
        //GameManager.Instance.ChangeCurrentPlayer();
    }

    public void SolveChain()
    {
        if (actionChainList.Count <= 0) return;

        actionChainList.Reverse();

        foreach (Action action in actionChainList)
        {
            action.ActionSolve();
        }

        actionChainList.Clear();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) SolveChain();
    }

}
