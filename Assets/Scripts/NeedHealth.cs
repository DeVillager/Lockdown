using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using Types;

public class NeedHealth : MonoBehaviour
{
    [SerializeField]
    private Color fullColor = Color.white;

    public Image image;
    private float maxWidth;
    Quaternion iniRot;

    [SerializeField]
    private NeedType needType;
    private Need need;

    private void Awake()
    {
        maxWidth = image.rectTransform.sizeDelta.x;
        iniRot = transform.rotation;
    }

    private void Start()
    {
        need = Player.Instance.GetNeed(needType);
    }


    private void Update()
    {
        float healthPercent = (float)need.Points / (float)need.MaxPoints;
        Vector2 size = image.rectTransform.sizeDelta;
        size.x = maxWidth * healthPercent;
        image.rectTransform.sizeDelta = size;
    }
}
