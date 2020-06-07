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
    public int itemsBought;
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

    public string PrintData()
    {
        string debug = "";
        foreach (Data data in gameData)
        {
            debug = $"TotalMoney:{data.money}  TaskPoints:{data.tasksDone}  TotalExp:{data.exp}";
            Debug.Log(debug);
        }
        return debug;
    }

    public string FinalValues()
    {
        return $"MoneyEarned:{money}  ExpEarned:{exp}  TaskPoints:{tasksDone}  ItemsBought:{itemsBought}";
    }

    public void ClearData()
    {
        money = 0;
        tasksDone = 0;
        needDecreaseTimes = 0;
        needDecreased = 0;
        exp = 0;
        itemsBought = 0;
        //gameData.Clear();
    }
}
