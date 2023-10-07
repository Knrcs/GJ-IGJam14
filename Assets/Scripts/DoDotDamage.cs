using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDotDamage : MonoBehaviour
{
    public int Amount;
    public float Time;
    public Life Life;

    private float _timeForDot;

    void Update()
    {
        _timeForDot -= UnityEngine.Time.deltaTime;
        if (_timeForDot < 0)
        {
            Life?.Damage(Amount);
            _timeForDot = Time;
        }
    }
}
