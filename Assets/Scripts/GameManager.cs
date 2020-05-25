using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private int daysToDeadLine = 20;
    [SerializeField]
    private int time = 9;

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
            if (time > 24)
            {
                DaysToDeadLine--;
                time %= 24;
            }
        }
    }
}
