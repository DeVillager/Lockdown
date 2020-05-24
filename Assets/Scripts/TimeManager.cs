using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    [SerializeField]
    private TextMeshProUGUI daysToDeadLineText;
    [SerializeField]
    private TextMeshProUGUI timeText;

    //TODO Remove update and change by call
    private void Update()
    {
        string amOrPm = GameManager.Instance.Time < 12 ? "AM" : "PM";
        timeText.text = $"{GameManager.Instance.Time % 12}.00 {amOrPm}";
        daysToDeadLineText.text = $"Days until deadline: {GameManager.Instance.DaysToDeadLine}";
    }
}
