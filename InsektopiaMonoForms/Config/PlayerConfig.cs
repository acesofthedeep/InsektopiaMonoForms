using System.Collections.Generic;
using System.Net.Sockets;

namespace InsektopiaMonoForms.Config;

public static class PlayerConfig
{
    private static GameState _currentGameState;
    public static string Identity { get; set; }

    public static GameState CurrentGameState
    {
        get => _currentGameState;
        set
        {
            GameStateHistory.Push(_currentGameState);
            _currentGameState = value;
        }
    }

    public static TcpClient Client { get; set; }

    public static Stack<GameState> GameStateHistory { get; set; } = new();
}