using System;
using UnityEngine;

public class MolesCatcher
{
    private InputSystem _inputSystem;
    private Camera _camera;

    public MolesCatcher(InputSystem inputSystem)
    {
        _inputSystem = inputSystem;

        _inputSystem.OnClicked += Click;//отписку

        _camera = Camera.main;
    }

    private void Click()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider.TryGetComponent(out Mole mole))
            {
                //MoleCatched?.Invoke(mole.RewardForCatching);
                mole.ApplyDamage(1);
            }
        }
    }
}
