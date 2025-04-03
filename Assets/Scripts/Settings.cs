using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public List<Toggle> fpsToggleList;
    public List<Toggle> windowToggleList;

    private void Start()
    {
        LoadSettings();
    }

    private void LoadSettings()
    {
        int fps = PlayerPrefs.GetInt("fps", 30);
        ChangeFps(fps);
        switch (fps)
        {
            case 30:
                fpsToggleList[0].isOn = true;
                break;
            case 60:
                fpsToggleList[1].isOn = true;
                break;
            case 120:
                fpsToggleList[2].isOn = true;
                break;
            default:
                fpsToggleList[3].isOn = true;
                break;
        }

        int screen = PlayerPrefs.GetInt("screen", 0);
        ChangeFullscreen(screen == 0 ? true : false);
        if (screen == 0)
        {
            windowToggleList[0].isOn = true;
        }
        else
        {
            windowToggleList[1].isOn = true;
        }
    }

    public void ChangeFps(int frame)
    {
        Application.targetFrameRate = frame;
        PlayerPrefs.SetInt("fps", frame);
    }

    public void ChangeFullscreen(bool screenMode)
    {
        if (screenMode)
        {
            Screen.fullScreen = true;
            PlayerPrefs.SetInt("screen", 0);
        }
        else
        {
            Screen.SetResolution(1920, 1080, false);
            PlayerPrefs.SetInt("screen", 1);
        }
    }
}