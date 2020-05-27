using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;
using TMPro;
using System;
using ValueType = Types.ValueType;

[Serializable]
public class Task : MonoBehaviour
{
    public string taskName;
    public string description;
    public TaskType taskType;
    public NeedType needType;
    public int requiredAmount;
    public int expPoints;
    [HideInInspector]
    public TextMeshProUGUI descriptionText;
    public ValueType valueType;
    [HideInInspector]
    public bool completed = false;

    private void Awake()
    {
        descriptionText = GetComponentInChildren<TextMeshProUGUI>();
        descriptionText.text = description;
    }

    

}
