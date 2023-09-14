using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private HealthView _healthView;
    private MolesHandler _molesHandler;
    private EndGameHandler _restartHandler;

    [SerializeField] private int _health;

    public void Initialize(MolesHandler molesHandler, EndGameHandler restartHandler)
    {
        _molesHandler = molesHandler;
        _restartHandler = restartHandler;

        molesHandler.PlayerDamaged += OnApplyDamage; //отписку

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
        if(_health < 0)
        {
            _health = 0;
            _healthView.ChangeHealth(_health);
            _restartHandler.LoseGame();
        }
    }
}
