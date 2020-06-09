using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slider : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public Color normalColor;
    public Color selectColor;
    public Image fillImage;

    public void OnSelect(BaseEventData eventData)
    {
        fillImage.color = selectColor;   
    }

    public void OnDeselect(BaseEventData eventData)
    {
        fillImage.color = normalColor;
    }
}
