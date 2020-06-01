using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    public Button startOverButtonGameOver;
    public TextMeshProUGUI debugTextGameOver;
    public Button startOverButtonVictory;
    public TextMeshProUGUI debugTextVictory;
    

    //[SerializeField]
    private string defaultText = "ARROWS = Moving\nLEFT CTRL = Use\nESC = Restart Lockdown";

    protected override void Awake()
    {
        base.Awake();
        SetText("");
    }

    private void Start()
    {
        SetDefaultText();
    }

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

    public void SetDebugText(TextMeshProUGUI debugText)
    {
        debugText.text = DataManager.Instance.FinalValues();
    }

    public void SetDefaultText()
    {
        SetText(defaultText);
    }
}
