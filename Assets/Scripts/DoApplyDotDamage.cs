using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoApplyDotDamage : MonoBehaviour
{
    public int amount;
    public float time;


    public void ApplyDot(GameObject target)
    {
        if (target.TryGetCommponentInLineage<Life>(out var life))
        {
            var ddd = life.gameObject.AddComponent<DoDotDamage>();

            ddd.Amount = amount;
            ddd.Time = time;
            ddd.Life = life;
        }
    }

    public void RemoveDot(GameObject target)
    {
        if (target.TryGetCommponentInLineage<DoDotDamage>(out var ddd))
        {
            Destroy(ddd);
        }
    }
}
