using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnCollide : MonoBehaviour
{
    public UnityEvent<GameObject> CollideEntered;
    public UnityEvent<GameObject> CollideExited;
    public UnityEvent<GameObject> Colliding;
    public bool OnlyPlayer = true;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (OnlyPlayer && !other.gameObject.TryGetCommponentInLineage<Player>(out var _))
        {
            return;
        }
        CollideEntered.Invoke(other.gameObject);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (OnlyPlayer && !other.gameObject.TryGetCommponentInLineage<Player>(out var _))
        {
            return;
        }
        CollideExited.Invoke(other.gameObject);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (OnlyPlayer && !other.gameObject.TryGetCommponentInLineage<Player>(out var _))
        {
            return;
        }
        Colliding.Invoke(other.gameObject);
    }
}
