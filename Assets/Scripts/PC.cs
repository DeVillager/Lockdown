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
        base.Use();
        OpenPC();
    }

    public void OpenPC()
    {
        homeWindow.SetActive(true);
        EventSystem.current.SetSelectedGameObject(firstButton);
        Time.timeScale = 0f;
    }

    public void ClosePC()
    {
        homeWindow.SetActive(false);
        Time.timeScale = 1f;
        EventSystem.current.SetSelectedGameObject(null);
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
