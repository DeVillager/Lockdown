using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Types;
using UnityEngine;

[System.Serializable]
public class Need
{
    [SerializeField]
    private NeedType type;
    [SerializeField]
    private int points;
    [SerializeField]
    private int depletionHours = 2;
    private int depletionTime;

    public NeedType Type { get => type; set => type = value; }
    public int Points { get => points; set => points = value; }
    public int DepletionHours { get => depletionHours; set => depletionHours = value; }
    public int DepletionTime { get => depletionTime; set => depletionTime = value; }

    public Need(NeedType type, int points)
    {
        this.Type = type;
        this.Points = points;
        this.DepletionTime = depletionHours;
    }

    public void DecreasePoints(int useTime)
    {
        //DecreasePointsByDepletionRate(useTime);
        Points--;
    }

    public void DecreasePointsByDepletionRate(int useTime)
    {
        int depletePoints = (int)(useTime / DepletionHours);
        int leftAmount = useTime % DepletionHours;
        DepletionTime -= leftAmount;
        if (DepletionTime <= 0)
        {
            DepletionTime += DepletionHours;
            depletePoints++;
        }
        Points -= depletePoints;
    }
}
