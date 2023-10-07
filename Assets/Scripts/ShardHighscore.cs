using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShardHighscore : MonoBehaviour
{
    public UnityEvent Collected;
    public int CurrentShards { get; private set; }

    public void CollectShard()
    {
        CurrentShards++;
        Collected.Invoke();
    }
}
