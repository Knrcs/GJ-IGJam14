using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoMove : MonoBehaviour
{
    public Vector2 Direction;
    public float Speed;

    public bool UseRigidbody;

    private Vector3 trueDirection;
    private Rigidbody2D rb;


    void Start()
    {
        var normalizedDir = Direction.normalized;
        trueDirection = new Vector3(normalizedDir.x, normalizedDir.y, 0);

        if (UseRigidbody)
        {
            gameObject.TryGetCommponentInLineage<Rigidbody2D>(out rb);
        }
    }

    private void FixedUpdate()
    {
        if (UseRigidbody)
        {
            rb.velocity = trueDirection * Speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!UseRigidbody)
        {
            transform.position += trueDirection * Speed * Time.deltaTime;
        }
    }
}
