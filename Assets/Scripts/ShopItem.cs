using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopItem : MonoBehaviour
{
    [SerializeField]
    public string itemName;
    [SerializeField]
    private TextMeshProUGUI nameText;
    [SerializeField]
    private int price;
    [SerializeField]
    private TextMeshProUGUI priceText;
    [SerializeField]
    private GameObject item;
    [SerializeField]
    private Vector2 location;
    [SerializeField]
    private GameObject nextShopItem;
    private int siblingIndex;

    private void Awake()
    {
        nameText.text = itemName;
        priceText.text = price + "G";
        //siblingIndex = transform.GetSiblingIndex();
        //AssignNextItem();
    }

    private void AssignNextItem()
    {
        int siblingIndex = transform.GetSiblingIndex();
        if (siblingIndex != 0)
        {
            nextShopItem = transform.GetChild(0).gameObject;
        } else
        {
            nextShopItem = transform.GetChild(1).gameObject;
        }
        //nextShopItem = transform.GetChild(siblingIndex + 1).gameObject;
        EventSystem.current.SetSelectedGameObject(nextShopItem);
    }

    public void Buy()
    {
        GameObject newItem = Instantiate(item, location, Quaternion.identity);
        newItem.name = itemName;
        AssignNextItem();
        Destroy(gameObject);
        //gameObject.SetActive(false);
    }
}
