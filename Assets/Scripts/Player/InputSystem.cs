using System;
using UnityEngine;

public class InputSystem : IUpdateable
{
    public event Action Clicked;

    public void Tick()
    {
        if (Input.GetMouseButtonDown(0))
            Clicked?.Invoke();
    }
}
