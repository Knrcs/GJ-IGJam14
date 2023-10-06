using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnTrigger : MonoBehaviour
{
    public UnityEvent<Collider2D> TriggerEntered;
    public UnityEvent<Collider2D> TriggerExited;
    public UnityEvent<Collider2D> Triggering;

    private void OnTriggerEnter2D(Collider2D other)
    {
        TriggerEntered.Invoke(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        TriggerExited.Invoke(other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Triggering.Invoke(other);
    }
}
