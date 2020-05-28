using System;
using System.Collections;
using System.Collections.Generic;
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
        StartCoroutine(ShowScreen(daysRemainingScreen, splashScreenTime));
        Player.Instance.NextDay();
        TaskManager.Instance.NextDay();
    }

    private IEnumerator ShowScreen(GameObject screen, float time)
    {
        Player.Instance.controller.enabled = false;
        screen.SetActive(true);
        yield return new WaitForSeconds(time);
        screen.SetActive(false);
        Player.Instance.controller.enabled = true;
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
