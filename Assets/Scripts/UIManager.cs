using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    private TextMeshProUGUI daysToDeadLineText;
    [SerializeField]
    private TextMeshProUGUI hoursRemainingText;
    [SerializeField]
    private TextMeshProUGUI moneyText;
    [SerializeField]
    private GameObject daysRemainingScreen;
    [SerializeField]
    private TextMeshProUGUI daysRemainingText;

    //TODO Remove update and change by call
    private void Update()
    {
        //string amOrPm = GameManager.Instance.Time < 12 ? "AM" : "PM";
        //timeText.text = $"{GameManager.Instance.Time % 12}.00 {amOrPm}";
        hoursRemainingText.text = $"Day remaining {24 - (GameManager.Instance.Time)}h";
        daysToDeadLineText.text = $"Days to deadline: {GameManager.Instance.DaysToDeadLine}";
        moneyText.text = $"Money\n{Player.Instance.money}G";

        daysRemainingText.text = $"Days to deadline\n{GameManager.Instance.DaysToDeadLine}";
    }
}
