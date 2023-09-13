using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEntryPoint : MonoBehaviour
{
    [SerializeField] private GameHandler _gameHandler;

    public void Start()
    {
        _gameHandler.Initialize();
    }
}
