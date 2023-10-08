using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    public int Amount;
    private Life playerlife;
    private bool _iframeForMe;
    
    public void DamageTarget(GameObject target)
    {
        if (target.TryGetCommponentInLineage<Life>(out var life))
        {
            if (!playerlife.iframeResistance)
            {
                Debug.Log("you got mail");
                life.Damage(Amount);
                playerlife.iframeResistance = true;
                playerlife.iframe = playerlife.iframeTime;
            }
            else
            {
                Debug.Log("iframe protection");
            }
        }
    }

    private void Awake()
    {
        playerlife = GameObject.Find("Player").GetComponent<Life>();
    }

    public void DamageThis()
    {
        DamageTarget(gameObject);
    }
}
