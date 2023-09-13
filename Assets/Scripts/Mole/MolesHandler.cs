using System;
using System.Collections.Generic;
using UnityEngine;

public class MolesHandler
{
    private List<Mole> _moles = new();

    public event Action<int> MoleReward; // rename
    public event Action<int> PlayerDamaged;

    public MolesHandler()
    {
        
    }

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
        MoleReward?.Invoke(reward); // fix
    }

    private void OnMoleEscaped(Mole mole, int damage)
    {
        RemoveMole(mole);
        PlayerDamaged?.Invoke(damage);
    }
}
