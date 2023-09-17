using System;
using UnityEngine;

public class Health : MonoBehaviour, IDisposable
{
    [SerializeField] private HealthView _healthView;
    [SerializeField] private int _health;

    private MolesContainer _molesContainer;
    private EndGameHandler _endGameHandler;

    public void Initialize(MolesContainer molesHandler, EndGameHandler restartHandler)
    {
        _molesContainer = molesHandler;
        _endGameHandler = restartHandler;

        _molesContainer.PlayerDamaged += OnDamageApplied;

        _healthView.Initialize();
        _healthView.ChangeHealth(_health);
    }

    private void OnDamageApplied(int damage)
    {
        _health -= damage;
        _healthView.ChangeHealth(_health);

        if (_health < 1)
        {
            _health = 0;
            _healthView.ChangeHealth(_health);
            _endGameHandler.LoseGame();
        }
    }

    public void Dispose()
    {
        _molesContainer.PlayerDamaged -= OnDamageApplied;
    }
}
