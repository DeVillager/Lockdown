using UnityEngine;
using System.Collections;
using Types;
using System;
using ValueType = Types.ValueType;

public class Player : Singleton<Player>
{
    public int startMoney = 5;
    public int needStartAmount = 5;
    private int money = 0;
    private int exp = 0;
    public Need[] needs;
    [HideInInspector]
    public PlayerController controller;

    public int Money { get => money; set => money = value; }
    public int Exp
    {
        get => exp;
        set
        {
            exp = value;
            if (exp >= GameManager.Instance.maxExp)
            {
                exp = 0;
                GameManager.Instance.maxExp += 2;
                GameManager.Instance.hourlyWage++;
                UIManager.Instance.SetText($"Level up!\nYour wage has increased to {GameManager.Instance.hourlyWage}.");
            }
        }
    }

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
        Reset();
    }


    public GameObject GetCollidingObject()
    {
        GameObject collObject = controller.collidedObject ? controller.collidedObject : null;
        return collObject;
    }

    public void IncreaseMoney(int amount)
    {
        TaskManager.Instance.IncreaseDailyPoints(ValueType.Money, amount);
        DataManager.Instance.money += amount;
        Money += amount;
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

    public void NextDay()
    {
        ResetPosition();
    }

    public void ResetPosition()
    {
        controller.Reset();
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

    public void Reset()
    {
        ResetNeeds();
        Money = startMoney;
    }

    public void ResetNeeds()
    {
        foreach (Need need in needs)
        {
            need.Points = needStartAmount;
        }
    }
}