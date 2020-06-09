using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private void Start()
    {
        if (GameManager.Instance != null)
        {
            Destroy(GameManager.Instance.gameObject);
        }
        //DisableMouse();
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

    public void PlaySelect()
    {
        SoundManager.Instance.PlayClick();
    }

    public void PlayCancel()
    {
        SoundManager.Instance.PlayCancel();
    }

    public void PlayStartGame()
    {
        SoundManager.Instance.PlayRecovery();
    }

    public void DisableMouse()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
