using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refrigerator : Item
{
    public int maxFoodAmount = 3;
    [HideInInspector]
    public int foodAmount;
    public bool super = false;

    private void Start()
    {
        foodAmount = maxFoodAmount;
        PC.Instance.refrigerator = this;
        if (super)
        {
            PC.Instance.foodOrderPrice = 0;
        }
    }

    public override void Use()
    {
        if (super)
        {
            base.Use();
            UIManager.Instance.SetText($"You ate some food.\nInfinite portions left.");
            return;
        }
        if (foodAmount > 0)
        {
            base.Use();
            foodAmount--;
            UIManager.Instance.SetText($"You ate some food.\n{foodAmount} portions left.");
        }
        else
        {
            UIManager.Instance.SetText("Refrigerator is empty!");
        }
    }

    public void Fill()
    {
        foodAmount = maxFoodAmount;
    }

    private void Update()
    {
        otherInfo = $"Food left: {foodAmount}";
    }
}
