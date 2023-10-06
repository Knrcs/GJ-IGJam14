using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndUi : MonoBehaviour
{
    public TMP_Text Text;
    public Image Bg;

    public void Win()
    {
        gameObject.SetActive(true);
        Text.text = "You have woken up and remembered your memory";
        Text.color = Color.black;
        Bg.color = Color.white;
    }

    public void Lose()
    {
        gameObject.SetActive(true);
        Text.text = "You have died";
        Text.color = Color.white;
        Bg.color = Color.black;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
