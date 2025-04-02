using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class FightEnemy : MonoBehaviour
{
    [Header("Movement Settings")] public float moveSpeed = 5f;
    public Animator animator;
    public int maxHp = 100;
    public int curHp = 100;
    public Image hpBar;
    public void TakeDamage(int damage)
    {
        curHp -= damage;
        changeHp(curHp,this.maxHp);
    }

    public void changeHp(int curHp, int maxHp)
    {
        float value = curHp * 1.0f / maxHp;
        hpBar.fillAmount = value;
    }
    
    void Start()
    {
        animator.SetBool("isrunning", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Damage damage = other.GetComponent<Damage>();
        if (other.CompareTag("WukongDamage"))
        {
            TakeDamage(damage.damage);
        }
    }

    void Update()
    {

    }
    
}