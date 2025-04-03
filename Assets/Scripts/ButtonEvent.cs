using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 普通按钮事件
/// </summary>
public class MainButton : MonoBehaviour
{
    public void BackHomeButtonClicked()
    {
        SceneManager.LoadScene("Main");
    }

    public void ExitButtonClicked()
    {
        Application.Quit();
    }

    public void IntroductionButtonClicked()
    {
        SceneManager.LoadScene("Introduction");
    }
    public void PlayMenuButtonClicked()
    {
        SceneManager.LoadScene("PlayMenu");
    }

    public void SettingsButtonClicked()
    {
        SceneManager.LoadScene("Settings");
    }
    public void LevelButtonClicked()
    {
        SceneManager.LoadScene("Level");
    }

    public void SelfTestButtonClicked()
    {
        SceneManager.LoadScene("SelfTest");
    }

    public void ARButtonClicked()
    {
        SceneManager.LoadScene("AR");
    }

    public void VRButtonClicked()
    {
        SceneManager.LoadScene("VR");
    }
    
}