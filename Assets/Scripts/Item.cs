using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    
    public Need[] restoredNeeds;

    public void Use()
    {
        foreach (Need need in restoredNeeds)
        {
            Need restoredNeed = Player.instance.GetNeed(need.Type);
            if (restoredNeed != null)
            {
                restoredNeed.Points += need.Points;
            }
        }
    }
}
