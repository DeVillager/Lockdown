using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : Singleton<ShopManager>
{
    public GameObject[] shopItems;
    public GameObject itemList;

    protected override void Awake()
    {
        base.Awake();
        Reset();
        //CreateShopItems();
    }

    public void Reset()
    {
        DestroyItems();
        CreateShopItems();
    }

    public void CreateShopItems()
    {
        foreach (GameObject shopItem in shopItems)
        {
            ShopItem newShopItem = CreateShopItem(shopItem);
            newShopItem.CreateItem();
            Destroy(newShopItem.gameObject);
        }
    }

    public ShopItem CreateShopItem(GameObject shopItem)
    {
        ShopItem newItem = Instantiate(shopItem, itemList.transform).GetComponent<ShopItem>();
        return newItem;
    }

    public void DestroyItems()
    {
        foreach (Transform child in itemList.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
