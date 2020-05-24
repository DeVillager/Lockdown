using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Types;
using UnityEngine;

[System.Serializable]
public class NeedText : MonoBehaviour
{
    [SerializeField]
    private NeedType needType = NeedType.Energy;
    private TextMeshProUGUI TMPtext;

    private void Awake()
    {
        TMPtext = GetComponent<TextMeshProUGUI>();
    }

    public void SetText()
    {
        int points = Player.Instance.GetNeed(needType).Points;
        string text = $"{needType} {points}";
        TMPtext.text = text;
    }
}
