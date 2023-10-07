using UnityEngine;
using UnityEngine.Events;

public enum GameState
{
    None,
    Nightmare,
    Dream,
    GameOver
}

public class GameHandler : Singleton<GameHandler>
{
    public GameObject Player { get; private set; }
    public PlayerMovementDream MovementDream { get; private set; }
    public PlayerMovementNightmare MovementNightmare { get; private set; }

    public UnityEvent NightmareStarted;
    public UnityEvent DreamStarted;

    public GameState State { get; private set; } = GameState.None;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Debug.Assert(Player != null, "Player not found!");

        MovementDream = Player.GetComponent<PlayerMovementDream>();
        Debug.Assert(MovementDream != null, "PlayerMovementDream not found on player!");

        MovementNightmare = Player.GetComponent<PlayerMovementNightmare>();
        Debug.Assert(MovementNightmare != null, "PlayerMovementNightmare not found on player!");

        StartNightmare();
    }

    public void StartDream()
    {
        if (State == GameState.Dream || State == GameState.GameOver)
        {
            return;
        }

        State = GameState.Dream;
        MovementNightmare.enabled = false;
        MovementDream.enabled = true;
    }

    public void StartNightmare()
    {
        if (State == GameState.Nightmare || State == GameState.GameOver)
        {
            return;
        }

        State = GameState.Nightmare;
        MovementNightmare.enabled = true;
        MovementDream.enabled = false;
    }
}
