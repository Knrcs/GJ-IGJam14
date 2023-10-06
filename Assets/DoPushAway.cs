using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoPushAway : MonoBehaviour
{
    public float Force;
    public Vector2 Direction;

    public void PushFromThis(GameObject target)
    {
        var direction = target.transform.position - transform.position;
        Push(target, direction);
    }

    public void PushToThis(GameObject target)
    {
        var direction = transform.position - target.transform.position;
        Push(target, direction);
    }

    public void PushTargetIntoDirection(GameObject target)
    {
        Push(target, Direction);
    }

    public void PushThisIntoDirection()
    {
        PushTargetIntoDirection(gameObject);
    }

    private void Push(GameObject target, Vector2 direction)
    {
        if (target.TryGetComponent<Rigidbody2D>(out var rb))
        {
            direction.Normalize();
            rb.AddForce(direction * Force);
        }
    }
}
