using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndUi : MonoBehaviour
{
    public TMP_Text Text;

    public void Win()
    {
        gameObject.SetActive(true);
        Text.text = "You have woken up and remembered your memory";
    }

    public void Lose()
    {
        gameObject.SetActive(true);
        Text.text = "You have died";
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
