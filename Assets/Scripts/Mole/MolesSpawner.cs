using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolesSpawner : MonoBehaviour
{
    [SerializeField] private List<Mole> _molePrefabs = new();
    [SerializeField] private int _spawnDelay;

    private GameBoard _gameBoard;
    private MolesContainer _molesContainer;
    private MoleFactory _moleFactory;

    public void Initialize(GameBoard gameBoard, MolesContainer molesHandler)
    {
        _gameBoard = gameBoard;
        _molesContainer = molesHandler;
        _moleFactory = new();

        StartCoroutine(SpawnMole());
    }

    private IEnumerator SpawnMole()
    {
        while (true)
        {
            if (_gameBoard.SearchEmptyHole())
            {
                var hole = _gameBoard.GetRandomEmptyHole();
                var randomPrefab = _molePrefabs[Random.Range(0, _molePrefabs.Count)];
                var mole = _moleFactory.GetMole(randomPrefab, hole.position);
                mole.Initialize();
                _molesContainer.AddMole(mole);
            }
            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
