using System;
using UnityEngine;

public class InputSystem : ITickable
{
    private const int LEFT_MOUSE = 0;

    public event Action<Vector3> Clicked;

    public void Tick()
    {
        if (Input.GetMouseButtonDown(LEFT_MOUSE))
            Clicked?.Invoke(Input.mousePosition);
    }
}
