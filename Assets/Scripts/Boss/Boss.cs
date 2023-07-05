using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    private Transform player; // �÷��̾��� ��ġ
    private bool isFlipped = false; // ������ ���� ������ �ִ���

    [SerializeField]
    private int maxHP = 300;
    [SerializeField]
    private int attackDamage = 20;
    [SerializeField]
    private int FlameAttackDemage = 40;
    [SerializeField]
    private Vector3 attackOffset;
    [SerializeField]
    private float attackRange = 1f;
    [SerializeField]
    private LayerMask attackMask;

    private GameObject deathEffect;
    private bool isInvulnerable = false; // ����

    public void LookAtPlayer() // ������ �÷��̾ �ٶ󺸰� �ϴ� ���
    {
        Vector3 flipped = transform.localScale; 
        flipped.x *= -1f; // x�� ����

        // ������ �÷��̾�� x�� �������� �� �����ʿ� �ְ�,
        // ������ �̹� ������ �ִٸ�(�÷��̾ �ٶ󺸰� �ִٸ�)
        // ������ �ٽ� ���� �������� ����
        if(transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        // ������ �÷��̾�� x�� �������� �� ���ʿ� �ְ�,
        // ������ ���� �������� �ʾҴٸ�(�÷��̾ ������ �ִٸ�)
        // ������ ����� �÷��̾ �ٶ󺸰� ��
        else if(transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    // ����� ����
    public void Attack()
    {
        Debug.Log("Attack");
        Vector3 pos = transform.position;
        // ���� ����
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        // ���� ���� �� ��ü Ž��
        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        // ���� ���� �� ��ü�� ������
        if(colInfo != null)
        {         
            //colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDemage);
        }
    }
    public void FlameAttack()
    {
        Debug.Log("FlameAttack");
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            //colInfo.GetComponent<PlayerHealth>().TakeDamage(FlameAttackDemage);
        }
    }

    public void TakeDamage()
    {
        if (isInvulnerable)
            return;

        if (maxHP % 100 == 0)
        {
            GetComponent<Animator>().SetBool("IsEnraged", true);
        }

        if (maxHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
