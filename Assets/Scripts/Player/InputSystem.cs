using System;
using UnityEngine;

public class InputSystem : IUpdateable
{
    public event Action OnClicked;

    public void Tick()
    {
        if (Input.GetMouseButtonDown(0))
            OnClicked?.Invoke();
    }
}
