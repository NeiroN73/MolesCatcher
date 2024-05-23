using System;
using UnityEngine;

public abstract class Condition
{
    public event Action ConditionCompleted;

    public void InvokeConditionCompleted()
    {
        Debug.Log("condition");
        ConditionCompleted?.Invoke();
    }
}