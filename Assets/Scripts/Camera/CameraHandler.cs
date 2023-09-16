using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class CameraHandler
{
    private GameBoard _gameBoard;
    private Camera _camera;

    public CameraHandler(GameBoard gameBoard)
    {
        _gameBoard = gameBoard;
        _camera = Camera.main;

        Vector3 cameraToObject = _gameBoard.transform.position - Camera.main.transform.position;
        float distance = -Vector3.Project(cameraToObject, Camera.main.transform.forward).y;

        Vector3 leftBot = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightTop = Camera.main.ScreenToWorldPoint(new Vector3(_camera.pixelWidth, _camera.pixelHeight, distance));

        Debug.Log(leftBot);
        Debug.Log(rightTop);
        Debug.Log(_gameBoard.GetCameraBorders());
        Debug.Log(_gameBoard.GetCameraBorders2());

        float x_left = Mathf.Abs(leftBot.x);
        float x_right = Mathf.Abs(rightTop.x);
        float z_top = Mathf.Abs(rightTop.z);
        float z_bot = Mathf.Abs(leftBot.z);

        while (Mathf.Abs(_gameBoard.GetCameraBorders().x) < x_left || Mathf.Abs(_gameBoard.GetCameraBorders().z) < x_right ||
            Mathf.Abs(_gameBoard.GetCameraBorders2().x) < z_top || Mathf.Abs(_gameBoard.GetCameraBorders2().z) < z_bot)
        {
            _camera.transform.position = new Vector3(0, _camera.transform.position.y + 1, _camera.transform.position.z + 1);
        }


    }
}
