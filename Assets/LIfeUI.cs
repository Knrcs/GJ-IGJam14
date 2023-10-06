using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LIfeUI : MonoBehaviour
{
    public Life Life;
    public TMP_Text Text;

    // Start is called before the first frame update
    void Awake()
    {
        Life.Birth.AddListener(UpdateText);
        Life.Changed.AddListener(_ => UpdateText());
        Life.Died.AddListener(UpdateText);
    }

    // Update is called once per frame
    void UpdateText()
    {
        if (Life.Dead)
        {
            Text.text = $"Ded";
        }
        else
        {
            Text.text = $"{Life.LifeCurrent}hp";
        }
    }


}
