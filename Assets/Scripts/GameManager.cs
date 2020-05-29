﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Types;
using UnityEditorInternal;
using UnityEngine;
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
    public int maxExp = 10;

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

    //TODO move to another script
    public void LoadNextDay()
    {
        Player.Instance.controller.enabled = true;
        StartCoroutine(ShowScreen(daysRemainingScreen, splashScreenTime));
        PCMenu.Instance.HideMenus();
        Player.Instance.NextDay();
        TaskManager.Instance.NewTask();
    }

    private IEnumerator ShowScreen(GameObject screen, float time)
    {
        //Player.Instance.controller.enabled = false;
        screen.SetActive(true);
        yield return new WaitForSeconds(time);
        screen.SetActive(false);
        //Player.Instance.controller.enabled = true;
        //Player.Instance.Reset();
    }

    public void GameEnd()
    {
        
        switch (gameState)
        {
            case GameState.Game:
                break;
            case GameState.GameOver:
                StartCoroutine(ShowScreen(gameOverScreen, gameEndTime));
                break;
            case GameState.Victory:
                StartCoroutine(ShowScreen(victoryScreen, gameEndTime));
                break;
            default:
                break;
        }
        DataManager.Instance.PrintData();
        ResetGame();
    }

    private void PrintData()
    {
        Debug.Log($"Money: {Player.Instance.Money}");
        Debug.Log($"Exp: {Player.Instance.Exp}");
        Debug.Log($"Tasks done: {TaskManager.Instance.tasksDone}");
    }

    public void ResetGame()
    {
        Debug.Log("Resetting game");
        daysToDeadLine = 10;
        time = 0;
        TaskManager.Instance.Reset();
        PCMenu.Instance.HideMenus();
        ShopManager.Instance.Reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        LoadNextDay();
    }

    public void SetGameOverMessage(string msg)
    {
        gameOverScreen.GetComponentInChildren<TextMeshProUGUI>().text = $"{msg}\n\nGAME OVER";
    }

    //TODO using same functions to display screens
    //private IEnumerator ShowScreen(GameObject screen, float time)
    //{
    //    Player.Instance.controller.enabled = false;
    //    daysRemainingScreen.SetActive(true);
    //    yield return new WaitForSeconds(time);
    //    daysRemainingScreen.SetActive(false);
    //    Player.Instance.controller.enabled = true;
    //}
}
