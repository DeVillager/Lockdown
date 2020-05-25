using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCMenu : MonoBehaviour
{
    public GameObject homeWindow;
    public GameObject shopWindow;

    private void Start()
    {
        homeWindow.SetActive(false);
        shopWindow.SetActive(false);
    }
}
