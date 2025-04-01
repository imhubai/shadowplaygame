using System;
using UnityEngine;

public class Pocket : MonoBehaviour
{
    private Collider2D _collider;

    [Header("Movement Settings")] public float moveSpeed = 5f;
    public float leftBoundary = -5f;
    public float rightBoundary = 5f;
    public Level3 levelController;
    private bool _isMovingLeft;
    private bool _isMovingRight;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DropItem"))
        {
            GameObject o = other.gameObject;
            ItemDrop itemDrop = o.GetComponent<ItemDrop>();
            levelController.SendMessage("PointChange", itemDrop.point);
            Destroy(other.gameObject);
        }
    }

    void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        HandleMovement();
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
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LeftButtonPressed();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RightButtonPressed();
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            LeftButtonPressed();
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            RightButtonPressed();
        }
    }


    private void HandleMovement()
    {
        Vector3 newPosition = transform.position;

        if (_isMovingLeft)
        {
            newPosition += moveSpeed * Time.deltaTime * Vector3.left;
        }

        if (_isMovingRight)
        {
            newPosition += moveSpeed * Time.deltaTime * Vector3.right;
        }

        newPosition.x = Mathf.Clamp(newPosition.x, leftBoundary, rightBoundary);
        transform.position = newPosition;
    }

    public void LeftButtonPressed() => _isMovingLeft = true;
    public void RightButtonPressed() => _isMovingRight = true;

    public void LeftButtonReleased() => _isMovingLeft = false;
    public void RightButtonReleased() => _isMovingRight = false;
}