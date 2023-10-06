using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    public int Amount;

    public void DamageTarget(GameObject target)
    {
        if (target.TryGetCommponentInLineage<Life>(out var life))
        {
            life.Damage(Amount);
        }
    }

    public void DamageThis()
    {
        DamageTarget(gameObject);
    }
}
