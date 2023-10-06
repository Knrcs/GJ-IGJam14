using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnTrigger : MonoBehaviour
{
    public UnityEvent<GameObject> TriggerEntered;
    public UnityEvent<GameObject> TriggerExited;
    public UnityEvent<GameObject> Triggering;

    private void OnTriggerEnter2D(Collider2D other)
    {
        TriggerEntered.Invoke(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        TriggerExited.Invoke(other.gameObject);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Triggering.Invoke(other.gameObject);
    }
}
