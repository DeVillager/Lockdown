using System;
using System.Collections;
using System.Collections.Generic;
using Types;
using UnityEngine;
using UnityEngine.EventSystems;

public class PC : Item
{
    public GameObject homeWindow;
    public GameObject shopWindow;
    public GameObject firstButton;
    public int mentality;
    public GameObject foodOrder;
    public Vector2 foodOrderPosition;

    public override void Use()
    {
        OpenPC();
    }

    public void Work()
    {
        int wage = GameManager.Instance.hourlyWage;
        UIManager.Instance.SetText($"You worked hard and earned {wage}G.");
        Player.Instance.money += wage;
        base.Use();
    }   
    
    public void Chat()
    {
        UIManager.Instance.SetText($"You called a friend.\nMentality (+{mentality})");
        Player.Instance.IncreaseNeed(NeedType.Mentality, mentality);
        base.Use();
    }

    //TODO OrderFood
    public void OrderFood()
    {
        Instantiate(foodOrder, foodOrderPosition, Quaternion.identity);
        base.Use();
    }

    public void OpenPC()
    {
        homeWindow.SetActive(true);
        EventSystem.current.SetSelectedGameObject(firstButton);
        Player.Instance.controller.enabled = false;
    }

    public void ClosePC()
    {
        homeWindow.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        Player.Instance.controller.enabled = true;
    }

    public void OpenShop()
    {
        homeWindow.SetActive(false);
        shopWindow.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void CloseShop()
    {
        shopWindow.SetActive(false);
        homeWindow.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
    }

}
