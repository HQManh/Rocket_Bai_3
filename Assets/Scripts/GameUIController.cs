using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour
{
    public static GameUIController Instance;
    int count;
    [SerializeField]
    TextMeshProUGUI text;
    [SerializeField]
    TextMeshProUGUI textEnd;
    [SerializeField]
    CanvasGroup start;
    [SerializeField]
    CanvasGroup end;


    void Start()
    {
        Instance = this;
        count = -1;
        UpdateScore();
    }

    public void UpdateScore()
    {
        count++;
        text.text = count.ToString();
        CheckWin();
    }

    public void EndGame(bool isWin)
    {
        LeanTween.alphaCanvas(end, 1f, 0.2f).setIgnoreTimeScale(true);
        end.blocksRaycasts = true;
        if (isWin )
        {
            textEnd.text = "Win";
        }
        else
        {
            textEnd.text = "Lose";
        }
    }

    public void StartBtn()
    {
        Time.timeScale = 0f;
        LeanTween.alphaCanvas(start, 0f, 0.2f).setIgnoreTimeScale(true).setOnComplete(() =>
        {
            Time.timeScale = 1f;
        });
        start.blocksRaycasts = false;
    }

    public void RetryBtn()
    {
        LeanTween.alphaCanvas(end, 0f, 0.2f);
        ReloadScreen();
    }

    void CheckWin()
    {
        if (count == 10)
        {
            Time.timeScale = 0f;
            EndGame(true);
        }
    }

    void ReloadScreen()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
