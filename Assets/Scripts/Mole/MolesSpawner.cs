using System.Collections;
using UnityEngine;

public class MolesSpawner : MonoBehaviour
{
    private GameBoard _gameBoard;
    [SerializeField] private MoleConfig[] _configs;
    private MolesHandler _molesHandler;

    public void Initialize(GameBoard gameBoard, MolesHandler molesHandler)
    {
        _gameBoard = gameBoard;
        _molesHandler = molesHandler;

        StartCoroutine(SpawnMole());
    }

    private IEnumerator SpawnMole()
    {
        while (true)
        {
            if (_gameBoard.SearchEmptyHole())
            {
                Transform hole = _gameBoard.GetRandomEmptyHole();
                var mole = _configs[Random.Range(0, _configs.Length)].GetMole(hole.position);
                mole.Initialize();
                _molesHandler.AddMole(mole);
            }
            yield return new WaitForSeconds(1); // fix later
        }
    }
}
