using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static bool TryGetCommponentInLineage<T>(this GameObject gameObject, out T output) where T : Component
    {
        var component = gameObject.GetComponent<T>();
        if (component != null)
        {
            output = component;
            return true;
        }

        component = gameObject.GetComponentInChildren<T>();
        if (component)
        {
            output = component;
            return true;
        }

        component = gameObject.GetComponentInParent<T>();
        if (component)
        {
            output = component;
            return true;
        }

        output = null;
        return false;
    }
}
