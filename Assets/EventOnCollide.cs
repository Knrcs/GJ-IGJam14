using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnCollide : MonoBehaviour
{
    public UnityEvent<GameObject> CollideEntered;
    public UnityEvent<GameObject> CollideExited;
    public UnityEvent<GameObject> Colliding;

    private void OnCollisionEnter2D(Collision2D other)
    {
        CollideEntered.Invoke(other.gameObject);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        CollideExited.Invoke(other.gameObject);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        Colliding.Invoke(other.gameObject);
    }
}
