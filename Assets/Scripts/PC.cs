﻿using System;
using System.Collections;
using System.Collections.Generic;
using Types;
using UnityEngine;
using UnityEngine.EventSystems;
using ValueType = Types.ValueType;

public class PC : Item
{
    public GameObject homeWindow;
    public GameObject shopWindow;
    public GameObject workButton;
    public int mentality;
    public GameObject foodOrder;
    public Vector2 foodOrderPosition;
    public int studyExp = 1;
    public int foodOrderPrice = 1;
    //private PCMenu pcMenu;
    public static PC Instance;
    [HideInInspector]
    public Refrigerator refrigerator;

    [HideInInspector]
    public PCType pcType = PCType.Normal;

    private void Start()
    {
        homeWindow = PCMenu.Instance.homeWindow;
        shopWindow = PCMenu.Instance.shopWindow;
        workButton = PCMenu.Instance.workButton;
        PCMenu.Instance.SetPC(this);
    }

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public override void Use()
    {
        OpenPC();
    }

    public void Work()
    {
        base.Use();
        int wage = GameManager.Instance.hourlyWage;
        UIManager.Instance.SetText($"You worked hard.\n(+{wage}G)");
        Player.Instance.IncreaseMoney(wage);
        TaskManager.Instance.IncreaseDailyPoints(ValueType.Work, UseTime);
    }

    public void Chat()
    {
        base.Use();
        UIManager.Instance.SetText($"You called a friend.\nMentality (+{mentality})");
        Player.Instance.IncreaseNeed(NeedType.Mentality, mentality);
    }

    //TODO OrderFood
    public void OrderFood()
    {
        if (refrigerator.foodAmount == refrigerator.maxFoodAmount)
        {
            UIManager.Instance.SetText($"Refrigerator is full already!");
            return;
        }
        if (Player.Instance.Money >= foodOrderPrice)
        {
            base.Use();
            refrigerator.Fill();
            Player.Instance.Money -= foodOrderPrice;
            UIManager.Instance.SetText($"Ordered some food.\nRefrigerator filled.");
        }
        else
        {
            UIManager.Instance.SetText($"Not enough money!");
        }
    }

    public void OpenPC()
    {
        UIManager.Instance.SetText($"I turned on PC.");
        homeWindow.SetActive(true);
        EventSystem.current.SetSelectedGameObject(workButton);
        Player.Instance.controller.enabled = false;
    }

    public void Study()
    {
        base.Use();
        UIManager.Instance.SetText($"You studied hard.\n(EXP +{studyExp})");
        DataManager.Instance.exp += studyExp;
        Player.Instance.Exp += studyExp;
        TaskManager.Instance.IncreaseDailyPoints(ValueType.Exp, studyExp);
    }

    public void ClosePC()
    {
        UIManager.Instance.SetText($"Shutting down PC...");
        EventSystem.current.SetSelectedGameObject(null);
        homeWindow.SetActive(false);
        Player.Instance.controller.enabled = true;
    }

    public void OpenShop()
    {
        UIManager.Instance.SetText($"Browsing the online shop.");
        homeWindow.SetActive(false);
        shopWindow.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void CloseShop()
    {
        UIManager.Instance.SetText($"Returning to home screen.");
        shopWindow.SetActive(false);
        homeWindow.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
    }

}
