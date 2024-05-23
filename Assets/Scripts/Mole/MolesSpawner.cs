using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MolesSpawner : ITickable
{
    private GameBoard _gameBoard;
    private MolesSpawnerConfigSO _molesSpawnerConfigSO;
    private MoleFactory _moleFactory;

    private Health _health;
    private Score _score;

    private float _time;

    [Inject]
    private void Construct(Health health, Score score)
    {
        _health = health;
        _score = score;
    }

    public MolesSpawner(GameBoard gameBoard, MolesSpawnerConfigSO molesSpawnerConfigSO)
    {
        _gameBoard = gameBoard;
        _molesSpawnerConfigSO = molesSpawnerConfigSO;

        _moleFactory = new();

        _time = _molesSpawnerConfigSO.SpawnDelay;
    }

    public void Tick()
    {
        _time -= Time.deltaTime;
        if(_time <= 0)
        {
            if (_gameBoard.SearchEmptyHole())
            {
                var hole = _gameBoard.GetRandomEmptyHole();
                var randomPrefab = _molesSpawnerConfigSO.MolePrefabs[Random.Range(0, _molesSpawnerConfigSO.MolePrefabs.Count)];
                var mole = _moleFactory.GetMole(randomPrefab, hole.position);
                mole.Catched += _score.AddScore;
                mole.Escaped += _health.TakeDamage;
            }

            _time = _molesSpawnerConfigSO.SpawnDelay;
        }
    }
}
