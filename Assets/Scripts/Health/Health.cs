using System;
using UnityEngine;

public class Health : MonoBehaviour, IDisposable
{
    [SerializeField] private HealthView _healthView;
    private MolesHandler _molesHandler;
    private EndGameHandler _restartHandler;

    [SerializeField] private int _health;

    public void Dispose()
    {
        _molesHandler.PlayerDamaged -= OnApplyDamage;
    }

    public void Initialize(MolesHandler molesHandler, EndGameHandler restartHandler)
    {
        _molesHandler = molesHandler;
        _restartHandler = restartHandler;

        _molesHandler.PlayerDamaged += OnApplyDamage; //отписку

        _healthView.Initialize();
        _healthView.ChangeHealth(_health);
    }

    private void OnApplyDamage(int damage)
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
            _restartHandler.LoseGame();
        }
    }
}
