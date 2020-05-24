using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data;
using Types;
using System;

public class NeedManager : MonoBehaviour
{
    public static NeedManager instance = null;
    public NeedText[] needTexts;

    //public TextMeshProUGUI energyText;
    //public TextMeshProUGUI funText;
    //public TextMeshProUGUI hygieneText;
    public TextMeshProUGUI infoText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateNeeds()
    {
        foreach (NeedText needText in needTexts)
        {
            needText.SetText();
        }
    }

    public void UpdateInfo()
    {
        GameObject collidedObject = Player.instance.GetCollidingObject();
        infoText.text = collidedObject != null ? $"Use {collidedObject.name}?" : "Do something";
    }
}
