using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Types;

public class UpgradePC : MonoBehaviour
{
    public int price = 10;
    private int level = 0;
    public TextMeshProUGUI priceText;

    private void Awake()
    {
        priceText.text = $"{price}G";    
    }

    public void Upgrade()
    {
        if (Player.Instance.Money >= price)
        {
            Player.Instance.Money -= price;
            MakeUpgrade();
            TaskManager.Instance.TaskDone(TaskAction.BuyItem);
            UIManager.Instance.SetText($"You upgraded PC!");
            DataManager.Instance.itemsBought++;
        }
        else
        {
            UIManager.Instance.SetText("Not enough money.");
        }
    }

    private void MakeUpgrade()
    {
        level++;
        if (level == 1)
        {
            PC.Instance.gameObject.name = "Fast PC";
            PC.Instance.studyExp++;
        }
        else if (level == 2)
        {
            PC.Instance.gameObject.name = "Super PC";
            PC.Instance.UseTime = 1;
        }
        else if (level >= 3)
        {
            PC.Instance.gameObject.name = "Quantum PC";
            PC.Instance.UseTime = 0;
            PC.Instance.studyExp++;
        }

    }
}
