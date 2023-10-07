using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = (T)FindObjectOfType(typeof(T));
        }

        if (Instance != this)
        {
            Destroy(this);
        }
    }
}
