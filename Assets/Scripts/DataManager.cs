using System.Collections;
using System.Collections.Generic;
using Types;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public int money;
    public int tasksDone;
    public int needDecreaseTimes;
    public int needDecreased;
    public int exp;
    private List<Data> gameData;

    private void Start()
    {
        gameData = new List<Data>();    
    }

    public void AddData()
    {
        Data data = new Data(this.money, this.tasksDone, this.needDecreaseTimes, this.needDecreased, this.exp);
        gameData.Add(data);
    }

    public void PrintData()
    {
        foreach (Data data in gameData)
        {
            Debug.Log($"{data.money}  {data.tasksDone}  {data.needIncreased}  {data.needDecreased}  {data.exp}");
        }
    }
}
