using UnityEngine;
using System.Collections;
using Types;
using System;

public class Player : Singleton<Player>
{
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

    //public void DepleteNeed(Need need, int useTime)
    //{
    //    int depletePoints = (int)(useTime / need.DepletionHours);
    //    int leftAmount = useTime % need.DepletionHours;
    //    need.DepletionTime -= leftAmount;
    //    if (need.DepletionTime <= 0)
    //    {
    //        need.DepletionTime += need.DepletionHours;
    //        depletePoints++;
    //    }
    //    need.Points -= depletePoints;
    //}

    public Item GetCollidingItem()
    {
        GameObject collObject = controller.collidedObject ? controller.collidedObject : null;
        if (collObject != null)
        {
            return controller.collidedObject.GetComponent<Item>();
        }
        return null;
    }

    //public void DepleteNeeds(int useTime)
    //{
    //    foreach (Need need in needs)
    //    {
    //        int depletePoints = (int)(useTime / need.DepletionHours);
    //        int leftAmount = useTime % need.DepletionHours;
    //        need.DepletionTime -= leftAmount;
    //        if (need.DepletionTime <= 0)
    //        {
    //            need.DepletionTime += need.DepletionHours;
    //            depletePoints++;
    //        }
    //        need.Points -= depletePoints;
    //        //if (need.DepletionTime <= 0)
    //        //{
    //        //    need.DepletionTime = need.DepletionHours;
    //        //    need.Points--;
    //        //}
    //    }
    //}
}