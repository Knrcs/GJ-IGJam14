using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MemoryUi : MonoBehaviour
{
    public List<GameObject> Blockers;

    private int counter;

    private void Awake()
    {
        GameHandler.Instance.GameStarted.AddListener(GameStart);
    }

    private void GameStart()
    {
        GameHandler.Instance.Shards.Collected.AddListener(RemoveBlocker);
    }

    public void RemoveBlocker()
    {
        if (counter >= Blockers.Count)
        {
            return;
        }

        Blockers[counter].SetActive(false);
        counter++;
    }

    public void ShowMemory()
    {
        gameObject.SetActive(true);
    }
}
