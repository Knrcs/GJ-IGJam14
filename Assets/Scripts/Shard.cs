using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shard : MonoBehaviour



{
public SFXManager sFXManager;

    public void GiveShard(GameObject target)
    {
        if (target.TryGetCommponentInLineage<ShardHighscore>(out var shard))
        {
            shard.CollectShard();
            sFXManager.PickupSFX();
        }
    }
}
