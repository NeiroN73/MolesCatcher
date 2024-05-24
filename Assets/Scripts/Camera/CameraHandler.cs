using UnityEngine;

public class CameraHandler
{
    private GameBoard _gameBoard;
    private CameraConfigSO _cameraConfigSO;
    private Camera _camera;

    public CameraHandler(GameBoard gameBoard, CameraConfigSO cameraConfigSO)
    {
        _gameBoard = gameBoard;
        _cameraConfigSO = cameraConfigSO;
        _camera = Camera.main;

        SetCameraHeight();
    }

    private void SetCameraHeight()
    {
        _camera.transform.position = Vector3.zero;

        float maxDistance = Mathf.Max(
            Vector3.Distance(_gameBoard.transform.position, _gameBoard.GetLeftDownCorner()),
            Vector3.Distance(_gameBoard.transform.position, _gameBoard.GetRightUpCorner()));

        _camera.transform.position = new Vector3(_camera.transform.position.x,
            _camera.transform.position.y + maxDistance * _cameraConfigSO.CameraHeightOffset,
            _camera.transform.position.z);
    }
}
