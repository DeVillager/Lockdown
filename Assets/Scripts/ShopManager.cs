using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : Singleton<ShopManager>
{
    Dictionary<string, GameObject> shopItems;
    public List<KeyValuePair<string, GameObject>> shopItemList;
    protected override void Awake()
    {
        base.Awake();
        foreach (KeyValuePair<string, GameObject> name in shopItemList)
        {
            shopItems[name.Key] = name.Value;
        }
    }
}
