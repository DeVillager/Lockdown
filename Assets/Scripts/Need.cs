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

    public NeedType Type { get => type; set => type = value; }
    public int Points { get => points; set => points = value; }

    public Need(NeedType type, int points)
    {
        this.Type = type;
        this.Points = points;
    }

}
