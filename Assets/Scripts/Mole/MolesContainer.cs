using System;
using System.Collections.Generic;

public class MolesContainer
{
    private List<Mole> _moles = new();

    public event Action<int> MoleCatchingReward;
    public event Action<int> PlayerDamaged;

    private Health _health;

    public void AddMole(Mole mole)
    {
        _moles.Add(mole);
        //mole.Catched += OnMoleDied;
        //mole.Escaped += OnMoleEscaped;
    }

    public void RemoveMole(Mole mole)
    {
        _moles.Remove(mole);
        //mole.Catched -= OnMoleDied;
        //mole.Escaped -= OnMoleEscaped;
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
