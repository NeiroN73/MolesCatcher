using System;
using UnityEngine;

public class Health : MonoBehaviour, IDisposable
{
    [SerializeField] private HealthView _healthView;
    [SerializeField] private int _health;

    private MolesHandler _molesHandler;
    private EndGameHandler _endGameHandler;

    public void Initialize(MolesHandler molesHandler, EndGameHandler restartHandler)
    {
        _molesHandler = molesHandler;
        _endGameHandler = restartHandler;

        _molesHandler.PlayerDamaged += OnDamageApplied;

        _healthView.Initialize();
        _healthView.ChangeHealth(_health);
    }

    private void OnDamageApplied(int damage)
    {
        _health -= damage;
        _healthView.ChangeHealth(_health);

        TryLoseGame();
    }

    private void TryLoseGame()
    {
        if(_health < 1)
        {
            _health = 0;
            _healthView.ChangeHealth(_health);
            _endGameHandler.LoseGame();
        }
    }

    public void Dispose()
    {
        _molesHandler.PlayerDamaged -= OnDamageApplied;
    }
}
