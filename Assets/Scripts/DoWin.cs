using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoWin : MonoBehaviour
{
    public void Win()
    {
        GameHandler.Instance.Win();
    }
}
