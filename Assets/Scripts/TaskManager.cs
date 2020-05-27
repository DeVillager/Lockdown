using UnityEngine;
using System;
using System.Collections.Generic;
using TMPro;
using Types;
using ValueType = Types.ValueType;//alias
using Random = UnityEngine.Random;

public class TaskManager : Singleton<TaskManager>
{
    public int tasksDone = 0;
    public int requiredTasksDone = 10;
    public ValueAmount[] valueAmounts;
    private Dictionary<ValueType, int> dailyPoints;

    public Task dailyTask;
    public GameObject[] tasks;
    private GameObject newTask;
    [SerializeField]
    private TextMeshProUGUI lockDownTasksDone;
    private int dailyTaskrequiredAmount = 0;

    protected override void Awake()
    {
        base.Awake();
    }

    public void NextDay()
    {
        InitDailyPoints();
        MakeDailyTask();
    }

    public void InitDailyPoints()
    {
        if (dailyPoints == null)
        {
            dailyPoints = new Dictionary<ValueType, int>();
        }
        else
        {
            dailyPoints.Clear();
        }
        foreach (ValueAmount valueAmount in valueAmounts)
        {
            dailyPoints[valueAmount.valueType] = valueAmount.amount;
        }
    }

    public void CheckProgress()
    {
        if (tasksDone >= requiredTasksDone)
        {
            GameManager.Instance.gameState = GameState.Victory;
        }
        else
        {
            GameManager.Instance.gameState = GameState.GameOver;
        }
        GameManager.Instance.GameEnd();
    }

    public void MakeDailyTask()
    {
        if (newTask != null)
        {
            Destroy(newTask);
        }
        int randInt = Random.Range(0, tasks.Length);
        newTask = Instantiate(tasks[randInt], transform);
        dailyTask = newTask.GetComponent<Task>();
        dailyTaskrequiredAmount = dailyTask.requiredAmount;
    }


    private void TaskDone(string doneTaskName)
    {
        if (dailyTask.taskName == doneTaskName)
        {
            GetReward();
        }
    }

    public void IncreaseDailyPoints(ValueType valueType, int amount)
    {
        dailyPoints[valueType] += amount;
        CheckIfDailyTaskDone();
        UpdateDailyTaskText();
    }

    public void GetReward()
    {
        if (dailyTask.completed)
        {
            return;
        }
        tasksDone++;
        Player.Instance.exp += dailyTask.expPoints;
        lockDownTasksDone.text = $"Lockdown tasks done:\n{tasksDone}/{requiredTasksDone}";
        dailyTask.completed = true;
    }

    private void CheckIfDailyTaskDone()
    {
        foreach (ValueType key in dailyPoints.Keys)
        {
            if (key == dailyTask.valueType && dailyPoints[key] >= dailyTask.requiredAmount)
            {
                GetReward();
            }
        }
    }


    private void UpdateDailyTaskText()
    {
        ValueType valueType = dailyTask.valueType;
        int remaining = dailyTaskrequiredAmount - dailyPoints[valueType];
        if (remaining > 0)
        {
            dailyTask.descriptionText.text = $"{dailyTask.description}\n({remaining} more)";
        }
        else
        {
            dailyTask.descriptionText.text = "Task done!";
        }
    }
}
