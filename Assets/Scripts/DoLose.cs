using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoLose : MonoBehaviour
{
    public void Lose()
    {
        GameHandler.Instance.Lose();
    }
}
