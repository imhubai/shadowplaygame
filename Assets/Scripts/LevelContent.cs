using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelContent : MonoBehaviour
{
    public TMP_Text levelName;
    public TMP_Text levelBest;
    public Image imageSuccess;
    public Image imageLocked;

    public string levelSceneName;
    
    public void Init(string name,string sceneName, int best, bool locked)
    {
        if (locked)
        {
            this.imageLocked.gameObject.SetActive(true);
        }
        else
        {
            this.imageSuccess.gameObject.SetActive(true);
        }

        if (best.IsUnityNull())
        {
            this.levelBest.gameObject.SetActive(false);
        }
        else
        {
            this.levelBest.gameObject.SetActive(true);
            StringBuilder stringBuilder = new StringBuilder();
            this.levelBest.SetText(stringBuilder.Append("最佳:").Append(best).Append("\n").Append("Best:").ToString());
        }
        this.levelName.SetText(name);
        this.levelSceneName = sceneName;
    }

    public void ButtonClicked()
    {
        SceneManager.LoadScene(levelSceneName);
    }
}
