using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [SerializeField] private int _boardSize;
    [SerializeField] private Transform _boardQuad;
    [SerializeField] private Hole _holePrefab;

    private List<Hole> _holes = new();

    public void Initialize()
    {
        BuildGameBoard();
    }

    private void BuildGameBoard()
    {
        _boardQuad.localScale = new Vector3(_boardSize, _boardSize, 1);

        var offset = (_boardSize - 1) * 0.5f;
        for (int i = 0, x = 0; x < _boardSize; x++)
        {
            for (int y = 0; y < _boardSize; y++, i++)
            {
                var hole = Instantiate(_holePrefab);
                _holes.Add(hole);
                hole.transform.SetParent(transform, false);
                hole.transform.localPosition = new Vector3(x - offset, 0, y - offset);
            }
        }
    }

    public Vector3 GetRightUpCorner()
    {
        var rightTop = new Vector3(_boardSize * 0.5f, 0, _boardSize * 0.5f);
        return rightTop;
    }

    public Vector3 GetLeftDownCorner()
    {
        var leftDown = new Vector3(-_boardSize * 0.5f, 0, -_boardSize * 0.5f);
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
