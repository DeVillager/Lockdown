using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Types;
using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
public class Need
{
    [SerializeField]
    private NeedType type;
    [SerializeField]
    private int points;
    [SerializeField]
    private int maxPoints = 10;
    //[SerializeField]
    //private int depletionHours = 2;
    private int depletionTime;
    public string gameOverMessage;
    public float decreaseProbability = 0.5f;

    public NeedType Type { get => type; set => type = value; }
    public int Points
    {
        get => points;
        set
        {
            points = Mathf.Clamp(value, 0, MaxPoints);
        }
    }

    //public int DepletionHours { get => depletionHours; set => depletionHours = value; }
    public int DepletionTime { get => depletionTime; set => depletionTime = value; }
    public int MaxPoints { get => maxPoints; set => maxPoints = value; }

    //public Need(NeedType type, int points)
    //{
    //    this.Type = type;
    //    this.Points = points;
    //    //this.DepletionTime = depletionHours;
    //}

    public void DecreasePoints(int useTime)
    {
        float rand = Random.Range(0f, 1f);
        if (rand < 0.5f)
        {
            Points--;
            DataManager.Instance.needDecreased++;
        }
        DataManager.Instance.needDecreaseTimes++;
        DataManager.Instance.AddData();


        if (Points <= 0)
        {
            NeedManager.Instance.SufferFromNeed(this);
        }
    }
}
