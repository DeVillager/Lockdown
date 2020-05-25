using System;
using System.Collections;
using System.Collections.Generic;
using Types;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private Need[] restoredNeeds;
    [SerializeField]
    private int useTime = 1;

    public int UseTime { get => useTime; set => useTime = value; }
    public Need[] RestoredNeeds { get => restoredNeeds; set => restoredNeeds = value; }

    public void Use()
    {
        foreach (Need playerNeed in Player.Instance.needs)
        {
            Need restoredNeed = GetNeed(playerNeed.Type);
            if (restoredNeed != null)
            {
                playerNeed.Points += restoredNeed.Points;
            }
            playerNeed.DecreasePoints(useTime);
        }
        GameManager.Instance.Time += UseTime;
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
}
