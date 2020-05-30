using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data;
using Types;
using System;

public class NeedManager : Singleton<NeedManager>
{
    public InfoText[] needTexts;
    public TextMeshProUGUI infoText;
    private GameManager gameManager;
    //public string gameOverMessage;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void UpdateNeeds()
    {
        foreach (InfoText needText in needTexts)
        {
            needText.SetNeedText();
        }
    }

    public void UpdateInfo()
    {
        GameObject collidedObject = Player.Instance.GetCollidingObject();
        if (collidedObject != null && Player.Instance.IsCollidingToItem())
        {
            infoText.text = $"Use {collidedObject.name}?";
        }
        else
        {
            infoText.text = "";
        }
    }

    public void SufferFromNeed(Need playerNeed)
    {
        if (GameManager.Instance.hardMode)
        {
            GameManager.Instance.SetGameOverMessage(playerNeed.gameOverMessage);
            GameManager.Instance.gameState = GameState.GameOver;
            //GameManager.Instance.GameEnd();
            return;
        }

        NeedType needType = playerNeed.Type;
        switch (needType)
        {
            case NeedType.Energy:
                playerNeed.Points = 10;
                gameManager.Time = 8;
                gameManager.DaysToDeadLine--;
                gameManager.LoadNextDay();
                break;
            case NeedType.Hunger:
                break;
            case NeedType.Fun:
                break;
            case NeedType.Hygiene:
                break;
            case NeedType.Mentality:
                break;
            default:
                break;
        }
    }
}
