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
    }

    private void AssignNextItem()
    {
        int siblingIndex = transform.GetSiblingIndex();
        if (siblingIndex != 0)
        {
            nextShopItem = transform.parent.GetChild(0).gameObject;
        }
        else
        {
            if (transform.parent.childCount == 1)
            {
                nextShopItem = transform.parent.parent.GetChild(2).gameObject;
            }
            else
            {
                nextShopItem = transform.parent.GetChild(1).gameObject;
            }
        }
        EventSystem.current.SetSelectedGameObject(nextShopItem);
    }

    public void Buy()
    {
        if (Player.Instance.Money >= price)
        {
            GameObject newItem = Instantiate(item, location, Quaternion.identity);
            newItem.name = itemName;
            Player.Instance.Money -= price;
            AssignNextItem();
            UIManager.Instance.SetText($"You bought {itemName}!");
            Destroy(gameObject);
        }
        else
        {
            UIManager.Instance.SetText("Not enough money.");
        }
    }
}
