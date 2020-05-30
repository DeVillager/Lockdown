using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI itemName;
    [SerializeField]
    private TextMeshProUGUI useTime;
    [SerializeField]
    private ItemRestores itemRestores;
    [SerializeField]
    private Image itemImage;
    [SerializeField]
    private TextMeshProUGUI otherInfo;

    private void Awake()
    {
        itemRestores = GetComponentInChildren<ItemRestores>();
    }



    void Update()
    {
        GameObject collidedObject = Player.Instance.GetCollidingObject();
        if (collidedObject != null && Player.Instance.IsCollidingToItem())
        {
            ShowItemInfo(collidedObject);
        }
        else
        {
            HideItemInfo();
        }
    }

    public void ShowItemInfo(GameObject collidedObject)
    {
        Item collidedItem = collidedObject.GetComponent<Item>();
        itemName.text = $"{collidedItem.gameObject.name}";
        useTime.text = $"Use time: {collidedItem.UseTime}h";
        otherInfo.text = collidedItem.otherInfo;
        itemRestores.ShowRestorePoints();
        itemImage.enabled = true;
        itemImage.sprite = collidedItem.GetSprite();
    }

    public void HideItemInfo()
    {
        itemName.text = "";
        useTime.text = "";
        otherInfo.text = "";
        itemRestores.HideRestorePoints();
        itemImage.enabled = false;
    }

    
}
