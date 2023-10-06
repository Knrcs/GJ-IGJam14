using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnCollide : MonoBehaviour
{
    public UnityEvent<Collision2D> CollideEntered;
    public UnityEvent<Collision2D> CollideExited;
    public UnityEvent<Collision2D> Colliding;

    private void OnCollisionEnter2D(Collision2D other)
    {
        CollideEntered.Invoke(other);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        CollideExited.Invoke(other);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        Colliding.Invoke(other);
    }
}
