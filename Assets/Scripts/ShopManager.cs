using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : Singleton<ShopManager>
{
    public GameObject[] shopItems;
    public Transform itemList;

    private void Start()
    {
        CreateItems();
    }

    public void Reset()
    {
        DestroyItems();
        CreateItems();
    }

    public void CreateItems()
    {
        foreach (GameObject shopItem in shopItems)
        {
            Instantiate(shopItem, itemList);
        }
    }

    public void DestroyItems()
    {
        foreach (Transform child in itemList.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
