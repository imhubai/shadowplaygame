using System.Collections;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public int point = 1;
    public float dropTime = 2f;
    [Range(0,100)]
    public float dropSpeed = 1f;
    private Rigidbody2D _rigidbody2d;
    
    void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _rigidbody2d.gravityScale = 0;
        StartCoroutine(Wait(dropTime));
    }
    IEnumerator Wait(float t)
    {
        yield return new WaitForSeconds(t);
        
        Drop();
    }

    void Drop()
    {
        _rigidbody2d.gravityScale = dropSpeed;
    }
}
