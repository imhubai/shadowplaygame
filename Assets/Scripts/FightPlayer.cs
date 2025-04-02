using UnityEngine;
using UnityEngine.Serialization;

public class FightPlayer : MonoBehaviour
{
    [Header("Movement Settings")] public float moveSpeed = 5f;
    private bool _isMovingLeft;
    private bool _isMovingRight;

    public Animator animator;
    void Start()
    {
        animator.SetBool("isrunning", false);
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
            LeftButtonReleased();
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            RightButtonReleased();
        }
    }


    private void HandleMovement()
    {
        Vector3 newPosition = transform.position;
        if (_isMovingLeft)
        {
            animator.SetBool("isrunning", true);
            newPosition += moveSpeed * Time.deltaTime * Vector3.left;
        }
        else if (_isMovingRight)
        {
            animator.SetBool("isrunning", true);
            newPosition += moveSpeed * Time.deltaTime * Vector3.right;
        }
        else
        {
            animator.SetBool("isrunning", false);
        }

        transform.position = newPosition;
    }

    public void AttackButtonClicked() => animator.SetTrigger("attack");
    public void LeftButtonPressed() => _isMovingLeft = true;
    public void RightButtonPressed() => _isMovingRight = true;

    public void LeftButtonReleased() => _isMovingLeft = false;
    public void RightButtonReleased() => _isMovingRight = false;
}