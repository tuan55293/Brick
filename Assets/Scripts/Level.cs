using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int currentLevel;
    public void Level1()
    {   
        currentLevel = 1;
        GameGUIManager.Ins.UpdateCurrentLevel(currentLevel);
        GameManager.Ins.timeLimit = 100;
        GameManager.Ins.spawnTime = 0.5f;
        GameManager.Ins.BirdSpeed = 2;
        GameManager.Ins.TargetGreenBirdKilled = 20;
        GameManager.Ins.TargetRedBirdKilled = 22;
        GameGUIManager.Ins.UpdateTargetMission();
        GameGUIManager.Ins.ShowDialogLevel(false);
        GameGUIManager.Ins.ShowGameGUI(true);
        GameManager.Ins.PlayGame();
    }
    public void Level2()
    {
        currentLevel = 2;
        GameGUIManager.Ins.UpdateCurrentLevel(currentLevel);
        GameManager.Ins.timeLimit = 200;
        GameManager.Ins.spawnTime = 0.5f;
        GameManager.Ins.BirdSpeed = 3;
        GameManager.Ins.TargetGreenBirdKilled = 20;
        GameManager.Ins.TargetRedBirdKilled = 30;
        GameGUIManager.Ins.UpdateTargetMission();
        GameGUIManager.Ins.ShowDialogLevel(false);
        GameGUIManager.Ins.ShowGameGUI(true);
        GameManager.Ins.PlayGame();

    }
    public void Level3()
    {
        currentLevel = 3;
        GameGUIManager.Ins.UpdateCurrentLevel(currentLevel);
        GameManager.Ins.timeLimit = 200;
        GameManager.Ins.spawnTime = 1f;
        GameManager.Ins.BirdSpeed = 3;
        GameManager.Ins.TargetGreenBirdKilled = 40;
        GameManager.Ins.TargetRedBirdKilled = 30;
        GameGUIManager.Ins.UpdateTargetMission();
        GameGUIManager.Ins.ShowDialogLevel(false);
        GameGUIManager.Ins.ShowGameGUI(true);
        GameManager.Ins.PlayGame();
    }
    public void Level4()
    {
        currentLevel = 4;
        GameGUIManager.Ins.UpdateCurrentLevel(currentLevel);
        GameManager.Ins.timeLimit = 250;
        GameManager.Ins.spawnTime = 0.5f;
        GameManager.Ins.BirdSpeed = 4;
        GameManager.Ins.TargetGreenBirdKilled = 40;
        GameManager.Ins.TargetRedBirdKilled = 40;
        GameGUIManager.Ins.UpdateTargetMission();
        GameGUIManager.Ins.ShowDialogLevel(false);
        GameGUIManager.Ins.ShowGameGUI(true);
        GameManager.Ins.PlayGame();
    }
    public void Level5()
    {
        currentLevel = 5;
        GameGUIManager.Ins.UpdateCurrentLevel(currentLevel);
        GameManager.Ins.timeLimit = 200;
        GameManager.Ins.spawnTime = 0.3f;
        GameManager.Ins.BirdSpeed = 5f;
        GameManager.Ins.TargetGreenBirdKilled = 35;
        GameManager.Ins.TargetRedBirdKilled = 45;
        GameGUIManager.Ins.UpdateTargetMission();
        GameGUIManager.Ins.ShowDialogLevel(false);
        GameGUIManager.Ins.ShowGameGUI(true);
        GameManager.Ins.PlayGame();
    }
    public void Level6()
    {
        currentLevel = 6;
        GameGUIManager.Ins.UpdateCurrentLevel(currentLevel);
        GameManager.Ins.timeLimit = 270;
        GameManager.Ins.spawnTime = 0.4f;
        GameManager.Ins.BirdSpeed = 6f;
        GameManager.Ins.TargetGreenBirdKilled = 55;
        GameManager.Ins.TargetRedBirdKilled = 45;
        GameGUIManager.Ins.UpdateTargetMission();
        GameGUIManager.Ins.ShowDialogLevel(false);
        GameGUIManager.Ins.ShowGameGUI(true);
        GameManager.Ins.PlayGame();
    }
    public void Level7()
    {
        currentLevel = 7;
        GameGUIManager.Ins.UpdateCurrentLevel(currentLevel);
        GameManager.Ins.timeLimit = 250;
        GameManager.Ins.spawnTime = 0.5f;
        GameManager.Ins.BirdSpeed = 7f;
        GameManager.Ins.TargetGreenBirdKilled = 50;
        GameManager.Ins.TargetRedBirdKilled = 40;
        GameGUIManager.Ins.UpdateTargetMission();
        GameGUIManager.Ins.ShowDialogLevel(false);
        GameGUIManager.Ins.ShowGameGUI(true);
        GameManager.Ins.PlayGame();
    }
    public void Level8()
    {
        currentLevel = 8;
        GameGUIManager.Ins.UpdateCurrentLevel(currentLevel);
        GameManager.Ins.timeLimit = 350;
        GameManager.Ins.spawnTime = 0.5f;
        GameManager.Ins.BirdSpeed = 8;
        GameManager.Ins.TargetGreenBirdKilled = 50;
        GameManager.Ins.TargetRedBirdKilled = 50;
        GameGUIManager.Ins.UpdateTargetMission();
        GameGUIManager.Ins.ShowDialogLevel(false);
        GameGUIManager.Ins.ShowGameGUI(true);
        GameManager.Ins.PlayGame();
    }
}
