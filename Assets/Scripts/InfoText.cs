using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Types;
using UnityEngine;

[System.Serializable]
public class InfoText : MonoBehaviour
{
    [SerializeField]
    private NeedType needType = NeedType.Energy;
    private TextMeshProUGUI TMPtext;

    private void Awake()
    {
        TMPtext = GetComponent<TextMeshProUGUI>();
    }

    public void SetNeedText()
    {
        int points = Player.Instance.GetNeed(needType).Points;
        string text = $"{needType}";
        TMPtext.text = text;
    }

    public void SetText(string text)
    {
        TMPtext.text = text;
    }
}
