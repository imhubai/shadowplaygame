using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButton : MonoBehaviour
{
    public void PlayButtonClicked()
    {
        SceneManager.LoadScene("PlayMenu");
    }

    public void BackHomeButtonClicked()
    {
        SceneManager.LoadScene("Main");
    }

    public void ExitButtonClicked()
    {
        Application.Quit();
    }

    public void LearnButtonClicked()
    {
        SceneManager.LoadScene("Learn");
    }

    public void LevelMenuButtonClicked()
    {
        SceneManager.LoadScene("LevelMenu");
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

    public void AchievementsButtonClicked()
    {
        SceneManager.LoadScene("Achievement");
    }
}