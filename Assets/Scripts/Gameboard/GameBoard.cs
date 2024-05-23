using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [SerializeField] private Transform _boardQuad;

    private List<Hole> _holes = new();
    private GameboardConfigSO _gameboardConfigSO;

    public void Initialize(GameboardConfigSO gameboardConfigSO)
    {
        _gameboardConfigSO = gameboardConfigSO;

        BuildGameBoard();
    }

    private void BuildGameBoard()
    {
        _boardQuad.localScale = new Vector3(_gameboardConfigSO.BoardSize, _gameboardConfigSO.BoardSize, 1);

        var offset = (_gameboardConfigSO.BoardSize - 1) * 0.5f;
        for (int i = 0, x = 0; x < _gameboardConfigSO.BoardSize; x++)
        {
            for (int y = 0; y < _gameboardConfigSO.BoardSize; y++, i++)
            {
                var hole = Instantiate(_gameboardConfigSO.HolePrefab);
                _holes.Add(hole);
                hole.transform.SetParent(transform, false);
                hole.transform.localPosition = new Vector3(x - offset, 0, y - offset);
            }
        }
    }

    public Vector3 GetRightUpCorner()
    {
        var rightTop = new Vector3(_gameboardConfigSO.BoardSize * 0.5f, 0, _gameboardConfigSO.BoardSize * 0.5f);
        return rightTop;
    }

    public Vector3 GetLeftDownCorner()
    {
        var leftDown = new Vector3(-_gameboardConfigSO.BoardSize * 0.5f, 0, -_gameboardConfigSO.BoardSize * 0.5f);
        return leftDown;
    }

    public Transform GetRandomEmptyHole()
    {
        while(true)
        {
            var hole = _holes[Random.Range(0, _holes.Count)];

            if (hole.IsEmpty)
            {
                return hole.transform;
            }
        }
    }

    public bool SearchEmptyHole()
    {
        foreach(var hole in _holes)
        {
            hole.StartRay();
            if(hole.IsEmpty)
            {
                return true;
            }
        }
        return false;
    }
}
