using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refrigerator : Item
{
    public int maxFoodAmount = 3;
    private int foodAmount;

    private void Start()
    {
        foodAmount = maxFoodAmount;
    }

    public override void Use()
    {
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
}
