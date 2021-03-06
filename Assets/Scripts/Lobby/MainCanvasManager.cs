using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasManager : MonoBehaviour
{
    public static MainCanvasManager instance;
    [SerializeField]
    private LobbyCanvas _lobbyCanvas;
    public LobbyCanvas lobbyCanvas
    {
        get { return _lobbyCanvas; }
    }
    [SerializeField]
    private CurrentRoomCanvas _currentRoomCanvas;
    public CurrentRoomCanvas currentRoomCanvas
    {
        get { return _currentRoomCanvas; }
    }
    private void Awake()
    {
        instance = this;
    }
}
