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
    public Life life;


    public void DotTargetTimer(GameObject target)
    {
        Debug.Log("Enter collisison");
        _timerActive = true;
    }

    public void DotTargetTimerOff(GameObject target)
    {
        Debug.Log("Exit collision");
        _timerActive = false;
        _timeForDot = time;
        
    }

    public void DotTargetDamage()
    {
        Debug.Log("Damage");
        
        life.Damage(amount);
    }

    void Update()
    {
        Timer();
    }

    private void Timer()
    {
        Debug.Log("Timer is listening");
        if(_timerActive)
        {
            Debug.Log("Timer is Active");
            if(_timeForDot > 0)
            {
                _timeForDot -= Time.deltaTime;
            }
            else if(_timeForDot < 0 && _damage)
            {
                DotTargetDamage();
                _damage = false;
                _timeForDot = time;
            }
            else
            {
                _damage = true;
            }
        }
    }
}
