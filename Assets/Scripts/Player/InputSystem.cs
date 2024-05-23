using System;
using UnityEngine;

public class InputSystem : ITickable
{
    public event Action<Vector3> Clicked;

    public void Tick()
    {
        if (Input.GetMouseButtonDown(0))
            Clicked?.Invoke(Input.mousePosition);
    }
}
