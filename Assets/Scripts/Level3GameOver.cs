using System;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

public class Level3GameOver : GameOver
{
    public void Init(bool win,bool hasScore,int score,int best,bool customMsg,string customMessage)
    {
        Time.timeScale = 0;
        if (win)
        {
            imageWin.SetActive(true);
        }
        else
        {
            imageLost.SetActive(true);
        }

        if (hasScore)
        {
            textScore.SetActive(true);
            StringBuilder stringBuilder = new StringBuilder();
            textScoreText.SetText(stringBuilder.Append("Score:").Append(score).Append("  ").Append("Best:")
                .Append(best)
                .ToString());
        }

        if (levelController.nextLevelSceneName != "" && !levelController.nextLevelSceneName.IsUnityNull())
        {
            buttonNextLevel.SetActive(true);
        }

        if (customMsg)
        {
            textMsgWin.SetText(customMessage);
            textMsgLost.SetText(customMessage);
        }
    }
}