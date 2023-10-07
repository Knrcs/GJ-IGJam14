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
    public GameEndUi GameEndUi { get; private set; }

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

        var GameEndUiObject = GameObject.FindGameObjectWithTag("GameEndUi");
        Debug.Assert(GameEndUiObject != null, "Couldnt find GameEndObject!");
        GameEndUi = GameEndUiObject.GetComponent<GameEndUi>();
        Debug.Assert(GameEndUi != null, "GameEndUI Component not found on GameEndUIObject!");

        GameEndUiObject.SetActive(false);

        State = GameState.None;
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

    public void Lose()
    {
        if (State == GameState.GameOver)
        {
            return;
        }

        State = GameState.GameOver;
        GameEndUi.Lose();
    }

    public void Win()
    {
        if (State == GameState.GameOver)
        {
            return;
        }

        State = GameState.GameOver;
        GameEndUi.Win();
    }
}
