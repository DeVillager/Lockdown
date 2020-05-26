using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : Singleton<TaskManager>
{
    private Dictionary<ValueType, int> dailyPoints;
    public int tasksDone = 0;
    private int dailyMoneyGot = 0;
    private int dailyHoursWorked = 0;
    public Task dailyTask;
    private GameObject[] tasks;
    private GameObject newTask;

    protected override void Awake()
    {
        base.Awake();
        dailyPoints = new Dictionary<ValueType, int>();
    }

    private void Start()
    {
        //MakeDailyTask();
    }

    public void MakeDailyTask()
    {
        newTask = Instantiate(tasks[0], transform);
        dailyTask = newTask.GetComponent<Task>();
    }

    public void ClearDailyPoints()
    {
        dailyPoints.Clear();
    }

    private void TaskDone(string doneTaskName)
    {
        if (dailyTask.name == doneTaskName)
        {
            GetReward();
        }
    }

    public void IncreaseDailyPoints(ValueType valueType, int amount)
    {
        dailyPoints[valueType] += amount;
    }

    public void GetReward()
    {
        tasksDone++;
        Player.Instance.exp += dailyTask.expPoints;
    }

    private void Update()
    {
        ValueType dailyTaskType = dailyTask.valueType;
        if (dailyPoints[dailyTaskType] >= dailyTask.requiredAmount)
        {
            GetReward();
        }
    }
}
