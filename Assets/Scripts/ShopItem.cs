using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Types;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ShopItem : MonoBehaviour, ISelectHandler
{
    [SerializeField]
    public string itemName;
    [SerializeField]
    private TextMeshProUGUI nameText;
    [SerializeField]
    private int price;
    [SerializeField]
    private TextMeshProUGUI priceText;
    public GameObject item;
    [SerializeField]
    private Vector2 location;
    private GameObject nextShopItem;
    private int siblingIndex;

    public GameObject[] unlockItems;
    public GameObject previousVersion = null;
    private GameObject newItem = null;
    public bool isUpgrade = false;

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
            Player.Instance.Money -= price;
            CreateItem();
            
            AssignNextItem();
            UIManager.Instance.SetText($"You bought {itemName}!");
            TaskManager.Instance.TaskDone(TaskAction.BuyItem);
            DataManager.Instance.itemsBought++;
            Destroy(gameObject);
        }
        else
        {
            UIManager.Instance.SetText("Not enough money.");
        }
    }

    public GameObject CreateItem()
    {
        if (previousVersion != null && isUpgrade)
        {
            Destroy(previousVersion);
        }
        newItem = Instantiate(item, location, Quaternion.identity);
        newItem.name = itemName;
        UnlockNewShopItems();
        return newItem;
    }

    public void UnlockNewShopItems()
    {
        foreach (GameObject shopItem in unlockItems)
        {
            ShopItem unlockedItem = ShopManager.Instance.CreateShopItem(shopItem);
            unlockedItem.previousVersion = newItem;
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        GameObject selectedObject = eventData.selectedObject;
        InfoManager.Instance.ShowShopItem(selectedObject);
    }

}
