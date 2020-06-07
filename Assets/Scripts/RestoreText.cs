using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Types;
using UnityEngine;

public class RestoreText : MonoBehaviour
{
    [SerializeField]
    private NeedType needType;
    private TextMeshProUGUI restoreText;

    private void Awake()
    {
        restoreText = GetComponent<TextMeshProUGUI>();
    }

    public void SetText()
    {
        Need need = Player.Instance.GetCollidingItem().GetNeed(needType);
        if (need != null)
        {
            restoreText.text = $"{needType} +{need.Points}";
        } else
        {
            restoreText.gameObject.SetActive(false);
        }
    }

    public void SetShopItemText(Item item)
    {
        Need need = item.GetNeed(needType);
        if (need != null)
        {
            restoreText.text = $"{needType} +{need.Points}";
        }
        else
        {
            restoreText.gameObject.SetActive(false);
        }
    }

}
