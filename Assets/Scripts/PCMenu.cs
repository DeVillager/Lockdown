using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PCMenu : Singleton<PCMenu>
{
    public GameObject homeWindow;
    public GameObject shopWindow;
    [SerializeField]
    private TextMeshProUGUI workText;

    private void Start()
    {
        homeWindow.SetActive(false);
        shopWindow.SetActive(false);
    }

    private void Update()
    {
        workText.text = $"Work (+{GameManager.Instance.hourlyWage}G)";
    }

}
