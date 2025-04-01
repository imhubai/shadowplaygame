using System.Collections;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Level1 : MonoBehaviour
{
    public float[] posList;
    public GameObject[] heartList;
    public int posIndex = 1;
    public bool isStart = false;
    public GameObject moveGroup;
    public GameObject player;
    public int winCount =4;
    public TMP_Text pointText;

    public int point;
    public int hp = 3;

    public float moveSpeed = 5f;
    public float wukongMoveDuration = 5f;
    private float _targetY;
    private bool _isMoving;

    public void ChangeHp(int value)
    {
        hp += value;
        if (hp < 0)
        {
            GameOver();
            return;
        }
        else
        {
            Destroy(heartList[hp]);
        }
    }

    public void GameOver()
    {
        Debug.Log("OVER");
    }
    public void GameWin()
    {
        Debug.Log("Win");
    }


    public void ChangePoint(int value)
    {
        this.point += value;
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(point).Append("/").Append(winCount);
        pointText.SetText(stringBuilder.ToString());
        if (point == winCount)
        {
            GameWin();
            return;
        }
    }

    void Start()
    {
    }

    void Update()
    {
        if (isStart && !moveGroup.IsUnityNull())
        {
            moveGroup.transform.position += moveSpeed * Time.deltaTime * Vector3.left;
        }

        KeyboardMovement();
    }

    void KeyboardMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        // Fun
        // if (v > 0)
        // {
        //     WukongMoveUp();
        // }
        // else if (v < 0)
        // {
        //     WukongMoveDown();
        // }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            WukongMoveDown();
        }else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            WukongMoveUp();
        }
    }
    
    public void WukongMoveUp()
    {
        if (posIndex > 0)
        {
            posIndex--;
        }

        _targetY = posList[posIndex];
        StartSmoothMove();
    }

    public void WukongMoveDown()
    {
        if (posIndex < posList.Length - 1)
        {
            posIndex++;
        }

        _targetY = posList[posIndex];
        StartSmoothMove();
    }

    public void StartSmoothMove()
    {
        if (!_isMoving)
        {
            StartCoroutine(SmoothMove());
        }
    }

    IEnumerator SmoothMove()
    {
        _isMoving = true;
        float elapsed = 0;
        Vector3 startPos = player.transform.position;

        while (elapsed < wukongMoveDuration)
        {
            float t = elapsed / wukongMoveDuration;
            t = Mathf.Sin(t * Mathf.PI * 0.5f);
            float newY = Mathf.Lerp(startPos.y, _targetY, t);
            player.transform.position = new Vector3(startPos.x, newY, startPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        player.transform.position = new Vector3(startPos.x, _targetY, startPos.z);
        _isMoving = false;
    }
}