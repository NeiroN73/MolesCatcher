using System;
using System.Collections.Generic;
using UnityEngine;

public class MolesHandler
{
    private List<Mole> _moles = new();

    public event Action<int> MoleCatchingReward;
    public event Action<int> PlayerDamaged;

    public void AddMole(Mole mole)
    {
        _moles.Add(mole);
        mole.MoleCatched += OnMoleDied;
        mole.MoleEscaped += OnMoleEscaped;
    }

    public void RemoveMole(Mole mole)
    {
        _moles.Remove(mole);
        mole.MoleCatched -= OnMoleDied;
        mole.MoleEscaped -= OnMoleEscaped;
    }

    private void OnMoleDied(Mole mole, int reward)
    {
        RemoveMole(mole);
        MoleCatchingReward?.Invoke(reward);
    }

    private void OnMoleEscaped(Mole mole, int damage)
    {
        RemoveMole(mole);
        PlayerDamaged?.Invoke(damage);
    }
}
