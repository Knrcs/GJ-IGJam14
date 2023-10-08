using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoHideAfterSeconds : MonoBehaviour
{
    public float Seconds = 3f;

    void Start()
    {
        StartCoroutine(Hide());
    }

    IEnumerator Hide()
    {
        yield return new WaitForSeconds(Seconds);
        gameObject.SetActive(false);
    }
}
