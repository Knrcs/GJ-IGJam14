using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    public int Amount;
    private Life playerlife;
    private bool _iframeForMe;
    private Animator _animator;
    
    public void DamageTarget(GameObject target)
    {
        if (target.TryGetCommponentInLineage<Life>(out var life))
        {
            if (!playerlife.iframeResistance)
            {
                life.Damage(Amount);
                _animator.SetTrigger("damage");
                playerlife.iframeResistance = true;
                playerlife.iframe = playerlife.iframeTime;
            }
            else
            {
            }
        }
    }

    private void Awake()
    {
        playerlife = GameObject.Find("Player").GetComponent<Life>();
        _animator = GameObject.Find("Player").GetComponent<Animator>();
    }

    public void DamageThis()
    {
        DamageTarget(gameObject);
    }
}
