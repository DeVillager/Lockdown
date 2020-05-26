using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;
using TMPro;

public class Task : MonoBehaviour
{
    public string name;
    public string description;
    public TaskType taskType;
    public NeedType needType;
    public int money;
    public int requiredAmount;
    public int expPoints;
    private TextMeshProUGUI descriptionText;
    public ValueType valueType;

    public Task(string name, TaskType taskType, int reqiredAmount)
    {
    }

    private void Awake()
    {
        descriptionText = GetComponentInChildren<TextMeshProUGUI>();
        descriptionText.text = description;
    }
}
