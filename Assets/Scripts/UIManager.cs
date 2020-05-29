using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    //[SerializeField]
    //private TextMeshProUGUI daysToDeadLineText;
    [SerializeField]
    private TextMeshProUGUI hoursRemainingText;
    [SerializeField]
    private TextMeshProUGUI moneyText;
    [SerializeField]
    private GameObject daysRemainingScreen;
    [SerializeField]
    private TextMeshProUGUI daysRemainingText;
    [SerializeField]
    private TextMeshProUGUI infoText;    
    [SerializeField]
    private TextMeshProUGUI playerExpText;


    //TODO Remove update and change by call
    private void Update()
    {
        hoursRemainingText.text = $"Day remaining {24 - (GameManager.Instance.Time)}h";
        moneyText.text = $"Money\n{Player.Instance.Money}G";
        daysRemainingText.text = $"Days until deadline\n{GameManager.Instance.DaysToDeadLine}";
        playerExpText.text = $"Player EXP: {Player.Instance.Exp}/{GameManager.Instance.maxExp}";
    }

    public void SetText(string text)
    {
        infoText.text = text;
    }
}
