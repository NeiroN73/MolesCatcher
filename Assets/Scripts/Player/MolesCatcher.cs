using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class MolesCatcher : IDisposable
{
    private readonly InputSystem _inputSystem;
    private readonly Camera _camera;

    public MolesCatcher(InputSystem inputSystem)
    {
        _inputSystem = inputSystem;
        _camera = Camera.main;

        _inputSystem.Clicked += OnClicked;
    }

    private void OnClicked(Vector3 mousePosition)
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(ray, out hit) == false)
            return;

        if (hit.collider.TryGetComponent(out Mole mole) == false)
            return;

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        mole.ApplyDamage();
    }

    public void Dispose()
    {
        _inputSystem.Clicked -= OnClicked;
    }
}
