using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameGUIManager : Singleton<GameGUIManager>
{
    public GameObject homeGUI;
    public GameObject gameGUI;

    public Dialog gameDialog;
    public Dialog pauseDialog;
    public Dialog levelDialog;
    public Dialog winDialog;

    public Image fireRateFilled;
    public Text timerText;
    public Text killedCountingBird;
    public Text killedCountingBird1;
    public Text currentLevel;

    [Header("Mission")]
    public Text targetRedBird;
    public Text targetGreenBird;



    //public Dialog CurDialog { get => m_curDialog; set => m_curDialog = value; }

    public override void Awake()
    {
        MakeSingleton(false);
    }
    public void ShowGameGUI(bool isShow)
    {
        if (gameGUI)
        {
            gameGUI.SetActive(isShow);
        }
        if (homeGUI)
        {
            homeGUI.SetActive(!isShow);
        }
    }

    public void ShowDialogLevel(bool isShow)
    {
        if (levelDialog)
        {
            levelDialog.ShowDialog(isShow);
        }
    }
    public void ShowWinDialog(bool isShow)
    {
        if (winDialog)
        {
            winDialog.ShowDialog(isShow);
        }
    }
    public void UpdateCurrentLevel(int level)
    {
        if (currentLevel)
        {
            currentLevel.text = "Level " + level;
        }
    }
    public void UpdateTimer(string text)
    {
        if (timerText != null)
        {
            timerText.text = text;
        }
    }
    public void UpdateTargetMission()
    {
        if (targetRedBird)
        {
            targetRedBird.text = "x" + GameManager.Ins.TargetRedBirdKilled;
        }
        if (targetGreenBird)
        {
            targetGreenBird.text = "x" + GameManager.Ins.TargetGreenBirdKilled;
        }
    }
    public void UpdateKillerCountingRedBird(int killed)
    {
        if (killedCountingBird != null)
        {
            killedCountingBird.text = "x" + killed.ToString();
        }
    }
    public void UpdateKillerCountingRedBird1(int killed)
    {
        if (killedCountingBird1 != null)
        {
            killedCountingBird1.text = "x" + killed.ToString();
        }
    }
    public void UpdateFireFilled(float rate)
    {
        if (fireRateFilled != null)
        {
            fireRateFilled.fillAmount = rate;
        }
    }

    public void SelectLevel()
    {
        winDialog.ShowDialog(false);
        gameDialog.ShowDialog(false);
        ShowDialogLevel(true);

    }

    public void BackHome()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }
    public void Resume()
    {
        Time.timeScale = 1;
        pauseDialog.ShowDialog(false);
    }
    public void Pause()
    {
        Time.timeScale = 0;
        pauseDialog.UpdateDialog("GAME PAUSE", "BEST KILLED : x" + Prefs.bestScore);
        pauseDialog.ShowDialog(true);
    }
    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }
    public void Exit()
    {
        Application.Quit();
    }

}
