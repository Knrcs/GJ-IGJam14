using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnTrigger : MonoBehaviour
{
    public UnityEvent<GameObject> TriggerEntered;
    public UnityEvent<GameObject> TriggerExited;
    public UnityEvent<GameObject> Triggering;

    public bool OnlyPlayer = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (OnlyPlayer && !other.gameObject.TryGetCommponentInLineage<Player>(out var _))
        {
            return;
        }
        TriggerEntered.Invoke(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (OnlyPlayer && !other.gameObject.TryGetCommponentInLineage<Player>(out var _))
        {
            return;
        }
        TriggerExited.Invoke(other.gameObject);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (OnlyPlayer && !other.gameObject.TryGetCommponentInLineage<Player>(out var _))
        {
            return;
        }
        Triggering.Invoke(other.gameObject);
    }
}
