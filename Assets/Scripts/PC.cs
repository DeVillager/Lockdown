using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PC : Item
{
    public GameObject homeWindow;
    public GameObject shopWindow;
    public GameObject firstButton;

    public override void Use()
    {
        //base.Use();
        OpenPC();
    }

    public void Work()
    {
        Player.Instance.money += GameManager.Instance.hourlyWage;
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
