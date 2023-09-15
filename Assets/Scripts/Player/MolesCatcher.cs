using System;
using UnityEngine;

public class MolesCatcher : IDisposable
{
    private readonly InputSystem _inputSystem;
    private readonly Camera _camera;

    private const int CLICK_DAMAGE = 1;

    public MolesCatcher(InputSystem inputSystem)
    {
        _inputSystem = inputSystem;
        _camera = Camera.main;

        _inputSystem.OnClicked += Click;
    }

    private void Click()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider.TryGetComponent(out Mole mole))
            {
                mole.ApplyDamage(CLICK_DAMAGE);
            }
        }
    }
    public void Dispose()
    {
        _inputSystem.OnClicked -= Click;
    }
}
