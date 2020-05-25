using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemRestores : MonoBehaviour
{
    [SerializeField]
    private RestoreText[] restoreTexts;

    public void ShowRestorePoints()
    {
        foreach (RestoreText restoreText in restoreTexts)
        {
            restoreText.gameObject.SetActive(true);
            restoreText.SetText();
        }
    }

    public void HideRestorePoints()
    {
        foreach (RestoreText restoreText in restoreTexts)
        {
            restoreText.gameObject.SetActive(false);
        }
    }

    
}
