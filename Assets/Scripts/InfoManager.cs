using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI itemName;
    [SerializeField]
    private TextMeshProUGUI useTime;
    [SerializeField]
    private ItemRestores itemRestores;

    private void Awake()
    {
        itemRestores = GetComponentInChildren<ItemRestores>();
    }



    void Update()
    {
        GameObject collidedObject = Player.Instance.GetCollidingObject();
        if (collidedObject != null)
        {
            Item collidedItem = collidedObject.GetComponent<Item>();
            itemName.text = $"{collidedItem.gameObject.name}";
            useTime.text = $"Use time: {collidedItem.UseTime}h";
            itemRestores.ShowRestorePoints();
        }
        else
        {
            itemName.text = "";
            useTime.text = "";
            itemRestores.HideRestorePoints();
        }
    }
}
