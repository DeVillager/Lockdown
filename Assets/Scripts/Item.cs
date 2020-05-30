using System;
using System.Collections;
using System.Collections.Generic;
using Types;
using UnityEngine;
using ValueType = Types.ValueType;

public class Item : MonoBehaviour
{
    [SerializeField]
    private Need[] restoredNeeds;
    [SerializeField]
    private int useTime = 1;
    [SerializeField]
    private string useMessage;
    public string otherInfo;

    public int UseTime { get => useTime; set => useTime = value; }
    public Need[] RestoredNeeds { get => restoredNeeds; set => restoredNeeds = value; }
    public string UseMessage { get => useMessage; set => useMessage = value; }
    private bool itemUsed = false;


    public virtual void Use()
    {
        itemUsed = true;
        string restoredMsg = "";
        foreach (Need playerNeed in Player.Instance.needs)
        {
            Need restoredNeed = GetNeed(playerNeed.Type);
            if (restoredNeed != null)
            {
                restoredMsg += $"({restoredNeed.Type} +{restoredNeed.Points})\n";
                Player.Instance.IncreaseNeed(restoredNeed.Type, restoredNeed.Points);
            }
            else
            {
                playerNeed.DecreasePoints(useTime);
            }
        }
        UIManager.Instance.SetText($"{UseMessage}\n{restoredMsg}");
        NeedManager.Instance.UpdateNeeds();
        DataManager.Instance.tasksDone = TaskManager.Instance.tasksDone;
        DataManager.Instance.AddData();
    }

    public void LateUpdate()
    {
        if (itemUsed)
        {
            GameManager.Instance.Time += UseTime;
            itemUsed = false;
        }
    }

    public Need GetNeed(NeedType needType)
    {
        foreach (Need need in restoredNeeds)
        {
            if (need.Type == needType)
            {
                return need;
            }
        }
        return null;
    }

    public Sprite GetSprite()
    {
        return transform.GetComponentInChildren<SpriteRenderer>().sprite;
    }
}
