using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        if (GameManager.Instance != null)
        {
            Destroy(GameManager.Instance.gameObject);
        }    
    }

    public void StartGame()
    {
        Debug.Log("Starting lockdown");
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
}
