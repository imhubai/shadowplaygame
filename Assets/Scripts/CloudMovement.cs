using System.Collections;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float downHeight = 2f;    // 下降高度
    public float speed = 1f;        // 移动速度（单位/秒）
    
    private float startY;            // 初始Y坐标
    private Coroutine moveCoroutine;
    private bool movingDown = true;  // 移动方向标记

    void Start()
    {
        startY = transform.position.y;
        moveCoroutine = StartCoroutine(SmoothMove());
    }

    void OnDisable()
    {
        if (moveCoroutine != null)
            StopCoroutine(moveCoroutine);
    }

    IEnumerator SmoothMove()
    {
        // 计算目标位置
        float targetYDown = startY - downHeight;
        float targetYUp = startY;

        while (true)
        {
            // 获取当前坐标的x/z值（保持不变）
            Vector3 currentPos = transform.position;
            
            // 确定目标Y坐标
            float targetY = movingDown ? targetYDown : targetYUp;
            
            // 移动过程
            while (Mathf.Abs(currentPos.y - targetY) > 0.01f)
            {
                // 使用Lerp平滑移动Y轴
                currentPos.y = Mathf.Lerp(
                    currentPos.y,
                    targetY,
                    speed * Time.deltaTime);
                
                transform.position = currentPos;
                yield return null;
                currentPos = transform.position; // 保持x/z不变
            }

            // 切换方向
            movingDown = !movingDown;
            yield return null;
        }
    }
}