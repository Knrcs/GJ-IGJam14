using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoIncreaseLife : MonoBehaviour
{
    public int Amount;
    public bool FullHeal;

    public void IncreaseCurrentLife(GameObject target)
    {
        if (target.TryGetCommponentInLineage<Life>(out var life))
        {
            if (FullHeal)
            {
                Debug.Log("Heal Full");
                life.Heal(life.LifeMax);
            }
            else
            {
                Debug.Log($"Heal Amount {Amount}");
                life.Heal(Amount);
            }
        }
    }

    public void IncreaseMaxLife(GameObject target)
    {
        if (target.TryGetCommponentInLineage<Life>(out var life))
        {
            Debug.Log($"Set maxlife Amount {Amount}");
            life.SetMaxHealth(life.LifeMax + Amount);
            IncreaseCurrentLife(target); //Always heal same amount that given to maxlife
        }
    }
}
