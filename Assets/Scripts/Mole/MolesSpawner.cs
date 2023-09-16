using System.Collections;
using UnityEngine;

public class MolesSpawner : MonoBehaviour
{
    [SerializeField] private MoleFactory[] _configs;
    [SerializeField] private int _spawnDelay;

    private GameBoard _gameBoard;
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
                var hole = _gameBoard.GetRandomEmptyHole();
                var randomConfig = _configs[Random.Range(0, _configs.Length)];
                var mole = randomConfig.GetMole(hole.position);
                mole.Initialize();
                _molesHandler.AddMole(mole);
            }
            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
