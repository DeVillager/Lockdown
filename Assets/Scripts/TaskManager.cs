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
    private bool taskDone = false;

    protected override void Awake()
    {
        base.Awake();
    }

    public void NewTask()
    {
        InitDailyPoints();
        MakeTask();
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
        lockDownTasksDone.text = $"Lockdown tasks done:\n{tasksDone}/{requiredTasksDone}";
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

    public void MakeTask()
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


    public void TaskDone(TaskAction doneTaskAction)
    {
        if (dailyTask.taskType == TaskType.Action && dailyTask.taskAction == doneTaskAction)
        {
            GetReward();
        }
    }

    public void IncreaseDailyPoints(ValueType valueType, int amount)
    {
        if (dailyTask.taskType == TaskType.Value)
        {
            dailyPoints[valueType] += amount;
            CheckIfDailyTaskDone();
        }
        //UpdateDailyTaskText();
    }

    public void GetReward()
    {
        tasksDone++;
        //Player.Instance.Exp += dailyTask.expPoints;
        lockDownTasksDone.text = $"Lockdown tasks done:\n{tasksDone}/{requiredTasksDone}";
        taskDone = true;
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

    public void Reset()
    {
        tasksDone = 0;
        NewTask();
    }

    private void UpdateDailyTaskText()
    {
        if (dailyTask == null)
        {
            return;
        }
        if (dailyTask.taskType == TaskType.Value)
        {
            ValueType valueType = dailyTask.valueType;
            int remaining = dailyTaskrequiredAmount - dailyPoints[valueType];
            if (remaining > 0)
            {
                dailyTask.descriptionText.text = $"{dailyTask.description}\n({remaining} more)";
            }
        }
        else
        {
            // TaskType is Action
            dailyTask.descriptionText.text = $"{dailyTask.description}";
        }
    }

    private void FixedUpdate()
    {
        UpdateDailyTaskText();
        if (taskDone)
        {
            taskDone = false;
            NewTask();
        }
    }
}
