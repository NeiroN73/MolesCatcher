using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartHandler : MonoBehaviour
{
    [SerializeField] private RestartMenuView _restartMenuView;
    [SerializeField] private string _winMessage;
    [SerializeField] private string _loseMessage;

    public void Initialize()
    {
        _restartMenuView.OnRestartClicked += RestartLevel; // отписка
    }

    public void RestartLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void WinGame()
    {
        _restartMenuView.Initialize();
        _restartMenuView.SetEndGameText(_winMessage);
    }

    public void LoseGame()
    {
        _restartMenuView.Initialize();
        _restartMenuView.SetEndGameText(_loseMessage);
    }
}
