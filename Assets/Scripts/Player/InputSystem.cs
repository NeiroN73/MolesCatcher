using System;
using UnityEngine;
using Zenject;

public class InputSystem : ITickable
{
    public event Action Clicked;

    public void Tick()
    {
        if (Input.GetMouseButtonDown(0))
            Clicked?.Invoke();
    }
}
