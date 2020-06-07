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
    public int requiredTasksDone = 50;
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
        lockDownTasksDone.text = $"Lockdown task points(TP):\n{tasksDone}/{requiredTasksDone}";
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

    public bool IncreaseDailyPoints(ValueType valueType, int amount)
    {
        if (dailyTask.taskType == TaskType.Value)
        {
            dailyPoints[valueType] += amount;
            CheckIfDailyTaskDone();
            return true;
        }
        return false;
    }

    public void GetReward()
    {
        tasksDone += dailyTask.rewardPoints;
        //Player.Instance.Exp += dailyTask.expPoints;
        lockDownTasksDone.text = $"Lockdown task points(TP):\n{tasksDone}/{requiredTasksDone}";
        taskDone = true;
    }

    private void CheckIfDailyTaskDone()
    {
        foreach (ValueType key in dailyPoints.Keys)
        {
            if (key == dailyTask.valueType && dailyPoints[key] >= dailyTask.requiredAmount && !taskDone)
            {
                GetReward();
                return;
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
            dailyTask.descriptionText.text = $"{dailyTask.description}";
            if (remaining > 0)
            {
                dailyTask.descriptionText.text += $"\n({remaining} more)";
            }
            dailyTask.descriptionText.text += $"\n[+{dailyTask.rewardPoints} TP]";
        }
        else
        {
            // TaskType is Action
            dailyTask.descriptionText.text = $"{dailyTask.description}";
            dailyTask.descriptionText.text += $"\n[+{dailyTask.rewardPoints} TP]";
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
