using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Types;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public int hourlyWage = 1;
    [SerializeField]
    private int daysToDeadLine = 20;
    [SerializeField]
    private int time = 0;
    [SerializeField]
    private float splashScreenTime = 1f;
    [SerializeField]
    private float gameEndTime = 10f;
    [SerializeField]
    private GameObject daysRemainingScreen;
    [SerializeField]
    private GameObject gameOverScreen;
    [SerializeField]
    private GameObject victoryScreen;

    public GameState gameState = GameState.Game;
    public bool testing = true;
    public bool hardMode = true;
    [HideInInspector]
    public int maxExp = 5;
    public int maxExpStart = 5;

    public int DaysToDeadLine { get => daysToDeadLine; set => daysToDeadLine = value; }
    public int Time
    {
        get
        {
            return time;
        }
        set
        {
            time = value;
            if (time >= 24)
            {
                time %= 24;
                DaysToDeadLine--;
                if (DaysToDeadLine <= 0)
                {
                    TaskManager.Instance.CheckProgress();
                }
                else
                {
                    LoadNextDay();
                }
            }
        }
    }

    private void Start()
    {
        LoadNextDay();
    }

    protected override void Awake()
    {
        base.Awake();
        maxExp = maxExpStart;
    }

    //TODO move to another script
    public void LoadNextDay()
    {
        //Player.Instance.controller.enabled = true;
        StartCoroutine(ShowScreen(daysRemainingScreen, splashScreenTime, false));
        PCMenu.Instance.HideMenus();
        Player.Instance.NextDay();
        TaskManager.Instance.NewTask();
    }

    private IEnumerator ShowScreen(GameObject screen, float time, bool endScreen)
    {
        Player.Instance.controller.enabled = false;
        //yield return new WaitForSeconds(0.5f);
        screen.SetActive(true);
        yield return new WaitForSeconds(time);
        screen.SetActive(false);
        //Player.Instance.controller.enabled = !endScreen;
        Player.Instance.controller.enabled = true;
        //if (endScreen)
        //{
        //    StartCoroutine(ShowScreen(daysRemainingScreen, splashScreenTime, false));
        //}
    }

    public void ShowEndScreen(GameObject screen)
    {
        if (screen.activeInHierarchy)
        {
            return;
        }
        Player.Instance.controller.enabled = false;
        SoundManager.Instance.PlayVictory();
        screen.SetActive(true);
        if (gameState == GameState.GameOver)
        {
            EventSystem.current.SetSelectedGameObject(UIManager.Instance.startOverButtonGameOver.gameObject);
            UIManager.Instance.SetDebugText(UIManager.Instance.debugTextGameOver);
        }
        else if (gameState == GameState.Victory)
        {
            EventSystem.current.SetSelectedGameObject(UIManager.Instance.startOverButtonVictory.gameObject);
            UIManager.Instance.SetDebugText(UIManager.Instance.debugTextVictory);
        }
    }

    private void Update()
    {
        if (gameState == GameState.GameOver || gameState == GameState.Victory)
        {
            GameEnd();
        }
    }

    public void GameEnd()
    {
        switch (gameState)
        {
            case GameState.Game:
                break;
            case GameState.GameOver:
                ShowEndScreen(gameOverScreen);
                //StartCoroutine(ShowScreen(gameOverScreen, gameEndTime, true));
                break;
            case GameState.Victory:
                ShowEndScreen(victoryScreen);
                //StartCoroutine(ShowScreen(victoryScreen, gameEndTime, true));
                break;
            default:
                break;
        }
    }

    private void PrintData()
    {
        Debug.Log($"Money: {Player.Instance.Money}");
        Debug.Log($"Exp: {Player.Instance.Exp}");
        Debug.Log($"Tasks done: {TaskManager.Instance.tasksDone}");
    }

    public void ResetGame()
    {
        Player.Instance.controller.enabled = true;
        UIManager.Instance.SetDefaultText();
        DataManager.Instance.PrintData();
        DataManager.Instance.ClearData();
        Debug.Log("Resetting game");
        gameState = GameState.Game;
        daysToDeadLine = 10;
        time = 0;
        hourlyWage = 1;
        PCMenu.Instance.HideMenus();
        ShopManager.Instance.DestroyItems();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        TaskManager.Instance.Reset();
        Player.Instance.Reset();
        Player.Instance.Exp = 0;
        Player.Instance.ResetPosition();
        PCMenu.Instance.HideMenus();
        //Player.Instance.NextDay();
        TaskManager.Instance.NewTask();
        SoundManager.Instance.PlayLockDown();
        //LoadNextDay();
    }

    public void MainMenu()
    {
        Destroy(DataManager.Instance.gameObject);
        Destroy(UIManager.Instance.gameObject);
        Destroy(Player.Instance.gameObject);

        gameState = GameState.Game;
        daysToDeadLine = 10;
        time = 0;
        hourlyWage = 1;

        SoundManager.Instance.PlayLockDown();
        Debug.Log("Loading main menu");
        SceneManager.LoadScene("MainMenu");
        //LoadNextDay();
    }

    public void SetGameOverMessage(string msg)
    {
        gameOverScreen.GetComponentInChildren<TextMeshProUGUI>().text = $"{msg}\n\nGAME OVER";
    }
}
