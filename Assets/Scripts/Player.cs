using UnityEngine;
using System.Collections;
using Types;
using System;

public class Player : Singleton<Player>
{
    public int money;
    public int exp = 0;
    public Need[] needs;
    public PlayerController controller;

    public Need GetNeed(NeedType type)
    {
        foreach (Need need in needs)
        {
            if (need.Type == type)
            {
                return need;
            }
        }
        return null;
    }

    protected override void Awake()
    {
        base.Awake();
        controller = GetComponent<PlayerController>();
    }

    public GameObject GetCollidingObject()
    {
        GameObject collObject = controller.collidedObject ? controller.collidedObject : null;
        return collObject;
    }

    public Item GetCollidingItem()
    {
        GameObject collObject = controller.collidedObject ? controller.collidedObject : null;
        if (collObject != null && controller.collidingToItem)
        {
            return controller.collidedObject.GetComponent<Item>();
        }
        return null;
    }

    public bool IsCollidingToItem()
    {
        return controller.collidingToItem;
    }

    public void IncreaseNeed(NeedType needType, int amount)
    {
        Need need = GetNeed(needType);
        need.Points += amount;
    }
}