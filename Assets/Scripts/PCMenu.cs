using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PCMenu : Singleton<PCMenu>
{
    public GameObject homeWindow;
    public GameObject shopWindow;
    public GameObject workButton;
    public GameObject backButtonInShop;
    public GameObject shopButton;
    [SerializeField]
    private TextMeshProUGUI workText;
    private PC pc;

    private void Start()
    {
        HideMenus();
    }

    public void HideMenus()
    {
        homeWindow.SetActive(false);
        shopWindow.SetActive(false);
    }

    private void Update()
    {
        workText.text = $"Work (+{GameManager.Instance.hourlyWage}G)";
    }

    public void SetPC(PC setPC)
    {
        pc = setPC;
    }

    public void Work()
    {
        pc.Work();
    }

    public void Chat()
    {
        pc.Chat();
    }

    //TODO OrderFood
    public void OrderFood()
    {
        pc.OrderFood();
    }

    public void OpenPC()
    {
        pc.OpenPC();
        EventSystem.current.SetSelectedGameObject(workButton);
    }

    public void ClosePC()
    {
        pc.ClosePC();
    }

    public void OpenShop()
    {
        pc.OpenShop();
        EventSystem.current.SetSelectedGameObject(backButtonInShop);
    }

    public void CloseShop()
    {
        pc.CloseShop();
        EventSystem.current.SetSelectedGameObject(shopButton);
    }
}
