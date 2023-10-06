using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    public int LifeMax = 2;
    public int LifeCurrent = 1;

    public UnityEvent Birth;
    public UnityEvent<int> Changed;
    public UnityEvent Died;
    public bool Dead;

    private void Start()
    {
        LifeCurrent = LifeMax;
        Birth.Invoke();
    }

    public void SetMaxHealth(int health)
    {
        LifeMax = health;
        Heal(0);
    }


    public void Damage(int amount)
    {
        if (Dead)
        {
            return;
        }

        LifeCurrent -= amount;
        LifeCurrent = Mathf.Clamp(LifeCurrent, 0, LifeMax);

        Changed.Invoke(amount);

        if (LifeCurrent <= 0)
        {
            Dead = true;
            Died.Invoke();
        }
    }

    public void Heal(int amount)
    {
        Damage(-amount);
    }
}
