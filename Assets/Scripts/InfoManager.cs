using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class InfoManager : Singleton<InfoManager>
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
    private bool itemShowed = false;
    [SerializeField]
    private TextMeshProUGUI needDecrease;

    protected override void Awake()
    {
        base.Awake();
        itemRestores = GetComponentInChildren<ItemRestores>();
    }


    void Update()
    {
        GameObject collidedObject = Player.Instance.GetCollidingObject();
        if (collidedObject != null && Player.Instance.IsCollidingToItem())
        {
            if (!itemShowed)
            {
                ShowItemInfo(collidedObject);
                itemShowed = true;
            }
        }
        else
        {
            HideItemInfo();
            itemShowed = false;
        }
    }

    public void ShowItemInfo(GameObject collidedObject)
    {
        Item collidedItem = collidedObject.GetComponent<Item>();
        itemName.text = $"{collidedItem.gameObject.name}";
        useTime.text = $"Use time: {collidedItem.UseTime}h";
        otherInfo.text = collidedItem.otherInfo;
        needDecrease.text = $"NeedDown:{collidedItem.decreaseChance * 100}%";
        itemRestores.ShowRestorePoints();
        itemImage.enabled = true;
        itemImage.sprite = collidedItem.GetSprite();
    }

    public void HideItemInfo()
    {
        itemName.text = "";
        useTime.text = "";
        otherInfo.text = "";
        needDecrease.text = "";
        itemRestores.HideRestorePoints();
        itemImage.enabled = false;
    }

    public void ShowShopItem(GameObject shopItemObject)
    {
        ShopItem shopItem = shopItemObject.GetComponent<ShopItem>();
        Item item = shopItem.item.GetComponent<Item>();
        Debug.Log($"{item.name}");
        itemName.text = $"{item.gameObject.name}";
        useTime.text = $"Use time: {item.UseTime}h";
        otherInfo.text = item.otherInfo;
        needDecrease.text = $"NeedDown:{item.decreaseChance * 100}%";
        itemRestores.ShowShopItemRestorePoints(item);
        itemImage.enabled = true;
        itemImage.sprite = item.GetSprite();
    }


}
