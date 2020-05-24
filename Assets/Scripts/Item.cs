using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private Need[] restoredNeeds;
    [SerializeField]
    private int useTime = 1;

    public void Use()
    {
        foreach (Need need in restoredNeeds)
        {
            Need restoredNeed = Player.Instance.GetNeed(need.Type);
            if (restoredNeed != null)
            {
                restoredNeed.Points += need.Points;
                GameManager.Instance.Time += useTime;
            }
        }
    }
}
