using UnityEngine;

/// <summary>
/// Level的超类
/// 用于规范isStart变量搭配Dialogue组件使用
/// (Dialogue播放完才进行游戏关卡)
/// </summary>
public class LevelController : MonoBehaviour
{
    public bool isStart = false;

    public void LevelStart()
    {
        isStart = true;
    }
}
