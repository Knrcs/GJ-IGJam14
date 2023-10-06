using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoIncreaseLife : MonoBehaviour
{
    public int Amount;
    public bool FullHeal;

    public void IncreaseCurrentLife(GameObject target)
    {
        if (target.TryGetComponent<Life>(out var life))
        {
            if (FullHeal)
            {
                life.Heal(life.LifeMax);
            }
            else
            {
                life.Heal(Amount);
            }
        }
    }

    public void IncreaseMaxLife(GameObject target)
    {
        if (target.TryGetComponent<Life>(out var life))
        {
            life.SetMaxHealth(life.LifeMax + Amount);
            IncreaseCurrentLife(target); //Always heal same amount that given to maxlife
        }
    }
}
