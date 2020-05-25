using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public int hourlyWage = 1;
    [SerializeField]
    private int daysToDeadLine = 20;
    [SerializeField]
    private int time = 9;
    [SerializeField]
    private float displayTime = 1f;
    [SerializeField]
    private GameObject daysRemainingScreen;

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
                DaysToDeadLine--;
                time %= 24;
                LoadNextDay();
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
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        StartCoroutine(ShowDaysRemainingScreen(displayTime));
    }

    private IEnumerator ShowDaysRemainingScreen(float time)
    {
        daysRemainingScreen.SetActive(true);
        yield return new WaitForSeconds(time);
        daysRemainingScreen.SetActive(false);
    }

}
