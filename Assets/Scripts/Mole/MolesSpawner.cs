using UnityEngine;

public class MolesSpawner : ITickable
{
    private GameBoard _gameBoard;
    private MolesSpawnerConfigSO _molesSpawnerConfigSO;
    private MoleFactory _moleFactory;

    private Health _health;
    private Score _score;

    private float _time;

    public MolesSpawner(GameBoard gameBoard, MolesSpawnerConfigSO molesSpawnerConfigSO, Health health, Score score)
    {
        _gameBoard = gameBoard;
        _molesSpawnerConfigSO = molesSpawnerConfigSO;
        _health = health;
        _score = score;

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

                if(_score != null)
                    mole.Catched += _score.AddScore;
                if(_health != null)
                    mole.Escaped += _health.TakeDamage;
            }

            _time = _molesSpawnerConfigSO.SpawnDelay;
        }
    }
}
