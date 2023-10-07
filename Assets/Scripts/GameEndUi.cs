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
    public MemoryUi MemoryUi;
    public GameObject ButtonParent;

    public float ButtonDelayOnWin = 2f;

    public void Win()
    {
        MemoryUi.gameObject.SetActive(false);
        ButtonParent.SetActive(false);
        gameObject.SetActive(true);
        Text.text = "";
        Text.color = Color.black;
        Bg.color = new Color(0, 0, 0, 0);

        MemoryUi.ShowMemory();

        StartCoroutine(ShowButtonsDelayed());
    }

    public IEnumerator ShowButtonsDelayed()
    {
        yield return new WaitForSeconds(2);
        ButtonParent.SetActive(true);
    }

    public void Lose()
    {
        MemoryUi.gameObject.SetActive(false);
        gameObject.SetActive(true);
        ButtonParent.SetActive(true);
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
