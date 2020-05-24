using UnityEngine;
using System.Collections;
using Types;
using System;

public class Player: Singleton<Player>
{
    //private static Player instance = null;
    public Need[] needs;

    private PlayerController controller;

    //public static Player Instance { get => instance; set => instance = value; }

    public Need GetNeed(NeedType type)
    {
        foreach (Need need in needs)
        {
            if (need.Type == type)
            {
                return need;
            }
        }
        return null;
    }

    protected override void Awake()
    {
        base.Awake();
        //if (Instance == null)
        //{
        //    Instance = this;
        //}
        //else if (Instance != this)
        //{
        //    Destroy(gameObject);
        //}
        //DontDestroyOnLoad(gameObject);
        controller = GetComponent<PlayerController>();
    }



    public GameObject GetCollidingObject()
    {
        GameObject collObject = controller.collidedObject ? controller.collidedObject : null;
        return collObject;
    }
}