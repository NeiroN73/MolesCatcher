using UnityEngine;

public class CameraHandler
{
    private GameBoard _gameBoard;
    private Camera _camera;

    public CameraHandler(GameBoard gameBoard)
    {
        _gameBoard = gameBoard;
        _camera = Camera.main;

        SetCameraHeight();
    }

    private void SetCameraHeight()
    {
        _camera.transform.position = Vector3.zero;
        for (int i = 0; i < 1000; i++)
        {
            float distance = Vector3.Distance(_gameBoard.transform.position, _camera.transform.position);

            Vector3 leftBot = _camera.ScreenToWorldPoint(new Vector3(0, 0, distance));
            Vector3 rightTop = _camera.ScreenToWorldPoint(
                new Vector3(_camera.pixelWidth, _camera.pixelHeight, distance));

            if (_gameBoard.GetLeftDownCorner().x > leftBot.x ||
                _gameBoard.GetRightUpCorner().x < rightTop.x)
            {
                return;
            }
            else
            {
                _camera.transform.position =
                    new Vector3(_camera.transform.position.x,
                    _camera.transform.position.y + 1,
                    _camera.transform.position.z);
            }
        }
    }
}
