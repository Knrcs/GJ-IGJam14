using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShardUi : MonoBehaviour
{
    public TMP_Text Text;

    private ShardHighscore ShardHighscore => GameHandler.Instance.Shards;
    private int MaxShards => GameHandler.Instance.MaxShards;

    private void Awake()
    {
        GameHandler.Instance.GameStarted.AddListener(GameStart);
    }

    private void GameStart()
    {
        ShardHighscore.Collected.AddListener(UpdateText);
        UpdateText();
    }

    private void UpdateText()
    {
        Text.text = $"{ShardHighscore.CurrentShards} / {MaxShards} Dreamshards";
    }
}
