using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDotDamage : MonoBehaviour
{
    public int amount;
    private float _timeForDot;
    public float time;
    private bool _damage;
    private bool _timerActive;

    public void DotTarget(GameObject target)
    {
        if (target.TryGetCommponentInLineage<Life>(out var life))
        {
            if(_damage)
            {
                life.Damage(amount);
                _damage = false;
            }

        }
    }

    public void DamageThis()
    {
        DotTarget(gameObject);
    }

    private void Timer()
    {
        if(_timerActive)
        {
            if(_timeForDot > 0)
            {
                _timeForDot -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Dot damage applied.");
                _damage = true;
                _timeForDot = time;
            }
        }
    }
}
