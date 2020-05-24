using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;        //Allows us to use SceneManager
using Types;
using System;

//Player inherits from MovingObject, our base class for objects that can move, Enemy also inherits from this.
public class Player: MonoBehaviour
{
    public static Player instance = null;
    public Need[] needs;

    private PlayerController controller;
    //public Need Energy
    //{
    //    get
    //    {
    //        return energy;
    //    }
    //    set
    //    {
    //        energy = value;
    //    }
    //}
    //public Need Fun
    //{
    //    get
    //    {
    //        return fun;
    //    }
    //    set
    //    {
    //        fun = value;
    //    }
    //}

    ////public int Hygiene
    ////{
    ////    get
    ////    {
    ////        return hygiene;
    ////    }
    ////    set
    ////    {
    ////        hygiene = value;
    ////    }
    ////}

    ////public int Money
    ////{
    ////    get
    ////    {
    ////        return money;
    ////    }
    ////    set
    ////    {
    ////        money = value;
    ////    }
    ////}

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

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        controller = GetComponent<PlayerController>();
    }

    private void Start()
    {
            
    }

    public GameObject GetCollidingObject()
    {
        return controller.collidedObject;
    }
}