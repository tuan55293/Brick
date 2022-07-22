using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Bird[] bird;
    public float spawnTime;
    private bool isGameOver;
    public Player player;
    float birdSpeed;

    public int timeLimit;
    int m_curTime;
    int m_birdKilled;
    int m_birdKilled2;

    [Header("Level")]
    int targetRedBirdKilled;
    int targetGreenBirdKilled;


    

    public int BirdKilled { get => m_birdKilled; set => m_birdKilled = value; }
    public bool IsGameOver { get => isGameOver; set => isGameOver = value; }
    public int BirdKilled2 { get => m_birdKilled2; set => m_birdKilled2 = value; }
    public int TargetRedBirdKilled { get => targetRedBirdKilled; set => targetRedBirdKilled = value; }
    public int TargetGreenBirdKilled { get => targetGreenBirdKilled; set => targetGreenBirdKilled = value; }
    public float BirdSpeed { get => birdSpeed; set => birdSpeed = value; }

    public override void Awake()
    {
        targetGreenBirdKilled = 1;
        targetRedBirdKilled = 1;
        MakeSingleton(false);
 

    }
    public override void Start()
    {
        player.gameObject.SetActive(false);
        GameGUIManager.Ins.ShowGameGUI(false);
        GameGUIManager.Ins.UpdateKillerCountingRedBird(m_birdKilled);
        GameGUIManager.Ins.UpdateKillerCountingRedBird1(m_birdKilled2);
        GameGUIManager.Ins.UpdateFireFilled(0);

    }
    private void FixedUpdate()
    {
        //Prefs.bestScore = m_birdKilled;
        WinLevel();
    }
    public void ShowMenuLevel()
    {
        GameGUIManager.Ins.ShowDialogLevel(true);  
    }
    public void PlayGame()
    {
        m_curTime = timeLimit;
        player.gameObject.SetActive(true);
        StartCoroutine(GameSpawn());
        StartCoroutine(TimeCountDown());
        GameGUIManager.Ins.ShowGameGUI(true);
    }

    public void WinLevel()
    {
        if(m_birdKilled >= TargetRedBirdKilled && m_birdKilled2 >= TargetGreenBirdKilled)
        {
            GameGUIManager.Ins.ShowWinDialog(true);
            StopAllCoroutines();
            m_birdKilled = 0;
            m_birdKilled2 = 0;
            m_curTime = 0;
            GameGUIManager.Ins.UpdateKillerCountingRedBird(0);
            GameGUIManager.Ins.UpdateKillerCountingRedBird1(0);
        }
    }
    IEnumerator TimeCountDown()
    {
        while (m_curTime > 0)
        {
            yield return new WaitForSeconds(1f);
            m_curTime--;
            GameGUIManager.Ins.UpdateTimer(IntToTime(m_curTime));
            if (m_curTime <= 0)
            {
                IsGameOver = true;
                GameGUIManager.Ins.gameDialog.UpdateDialog("You Lose", "Chicken");
                GameGUIManager.Ins.gameDialog.ShowDialog(true);
                StopAllCoroutines();
                isGameOver = false;
            }
        }
    }
    IEnumerator GameSpawn()
    {
        while (!IsGameOver )
        {
            SpawnBird();
            yield return new WaitForSeconds(spawnTime);
        }
    }
    void SpawnBird()
    {
        Vector3 spawPos = Vector3.zero;
        float randCheck = Random.Range(0, 10);

        if (randCheck >= 5f)
        {
            spawPos = new Vector3(12, Random.Range(-1f, 3f), 0);
        }
        else
        {
            spawPos = new Vector3(-12, Random.Range(-1f, 3f), 0);
        }
        if (bird != null && bird.Length > 0)
        {
            int rand = Random.Range(0, bird.Length);
            if (bird[rand] != null)
            {
                Instantiate(bird[rand], spawPos, Quaternion.identity);
                Debug.Log(birdSpeed);
            }
        }
    }

    string IntToTime(int time)
    {
        float minute = Mathf.Floor(time / 60);
        float second = Mathf.RoundToInt(time % 60);
        return minute.ToString("00") + " : " + second.ToString("00");
    }
}
