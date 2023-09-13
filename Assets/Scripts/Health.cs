using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private HealthView _healthView;
    private MolesHandler _molesHandler;
    private RestartHandler _restartHandler;

    [SerializeField] private int _health;

    public void Initialize(MolesHandler molesHandler, RestartHandler restartHandler)
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
    }
}
