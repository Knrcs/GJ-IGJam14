using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoChangeState : MonoBehaviour
{
    public void StartDream()
    {
        GameHandler.Instance.StartDream();
    }

    public void StartNightmare()
    {
        GameHandler.Instance.StartNightmare();

    }

    public void StartTransition()
    {
        GameHandler.Instance.StartTransition();
    }
}
