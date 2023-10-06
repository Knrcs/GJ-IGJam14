using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDestroy : MonoBehaviour
{
    public void DestroyThis()
    {
        Destroy(gameObject);
    }

    public void DestroyTarget(GameObject target)
    {
        Destroy(target);
    }
}
