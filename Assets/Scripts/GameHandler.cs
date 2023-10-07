using System.Linq;
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
    public UnityEvent GameAwoken;
    public UnityEvent GameStarted;

    public float OffsetYDeathFromAbove;

    public GameObject Player { get; private set; }
    public GameObject DeathFromAbove { get; private set; }
    public PlayerMovementDream MovementDream { get; private set; }
    public PlayerMovementNightmare MovementNightmare { get; private set; }
    public ShardHighscore Shards { get; private set; }
    public Life Life { get; private set; }
    public GameEndUi GameEndUi { get; private set; }

    public int MaxShards { get; private set; }

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

        Shards = Player.GetComponent<ShardHighscore>();
        Debug.Assert(Shards != null, "Shards not found on player!");
        Life = Player.GetComponent<Life>();
        Debug.Assert(Life != null, "Life not found on player!");

        var GameEndUiObject = GameObject.FindGameObjectWithTag("GameEndUi");
        Debug.Assert(GameEndUiObject != null, "Couldnt find GameEndObject!");
        GameEndUi = GameEndUiObject.GetComponent<GameEndUi>();
        Debug.Assert(GameEndUi != null, "GameEndUI Component not found on GameEndUIObject!");

        DeathFromAbove = GameObject.FindGameObjectWithTag("DeathFromAbove");
        Debug.Assert(DeathFromAbove != null, "DeathFromAbove not found!");

        GameEndUiObject.SetActive(false);

        MaxShards = FindObjectsOfType<Shard>().Count();

        State = GameState.None;
        StartNightmare();

        //For events that need to hook into player birth
        GameAwoken.Invoke();

        //For events that can happen simultanious with player birth
        GameStarted.Invoke();
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
        DeathFromAbove.SetActive(false);
    }

    private void ResetDeathFromAbove()
    {
        var posY = Player.transform.position.y + OffsetYDeathFromAbove;
        var newPos = DeathFromAbove.transform.position;
        newPos.y = posY;
        DeathFromAbove.transform.position = newPos;
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
        DeathFromAbove.SetActive(true);
        ResetDeathFromAbove();
    }

    public void Lose()
    {
        if (State == GameState.GameOver)
        {
            return;
        }

        State = GameState.GameOver;
        GameEndUi.Lose();
        Life.Invulnerable = true;
    }

    public void Win()
    {
        if (State == GameState.GameOver)
        {
            return;
        }

        State = GameState.GameOver;
        GameEndUi.Win();
        Life.Invulnerable = true;
    }
}
