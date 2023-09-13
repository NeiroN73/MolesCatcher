using System;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public event Action OnClicked;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            OnClicked?.Invoke();
    }
}
