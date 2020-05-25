using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data;
using Types;
using System;

public class NeedManager : Singleton<NeedManager>
{
    public NeedText[] needTexts;
    public TextMeshProUGUI infoText;

    public void UpdateNeeds()
    {
        foreach (NeedText needText in needTexts)
        {
            needText.SetText();
        }
    }

    public void UpdateInfo()
    {
        GameObject collidedObject = Player.Instance.GetCollidingObject();
        if (collidedObject != null && Player.Instance.IsCollidingToItem())
        {
            infoText.text = $"Use {collidedObject.name}?";
        }
        else
        {
            infoText.text = "";
        }
    }
}
