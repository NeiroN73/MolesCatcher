using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler
{
    private GameBoard _gameBoard;
    private Camera _camera;

    public CameraHandler(GameBoard gameBoard)
    {
        _gameBoard = gameBoard;
        _camera = Camera.main;

        var coef = _gameBoard.CameraSizeCoefficient;
        _camera.transform.position = new Vector3(_camera.transform.position.x, _camera.transform.position.y * coef, _camera.transform.position.z * coef);
    }
}
