using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;

public class Level3 : MonoBehaviour
{
    public int point;
    public int lostGinseng;
    public TMP_Text pointText;
    public TMP_Text timeText;
    public int time = 100;
    
    public void PointChange(int point)
    {
        this.point += point;
        pointText.SetText(this.point.ToString());
    }
    public void LostGinsengChange(int count)
    {
        this.lostGinseng += count;
    }
    void Start()
    {
        StartCoroutine(ChangeTime());
    }
    
    void Update()
    {
        
    }
    
    private IEnumerator ChangeTime()
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(time / 60).Append(":").Append(time % 60);
            timeText.SetText(stringBuilder.ToString());
        }
        GameOver();
    }

    private void GameOver()
    {
    }
}
