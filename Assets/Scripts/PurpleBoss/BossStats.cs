using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : Enemy
{
    [SerializeField] private BossController controller;

    public override void HurtSequence()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Dmg"))
            return;
        anim.SetTrigger("Damage");
    }

    public override void DeathSequence()
    {
        base.DeathSequence();
        controller.ChangeState(BossState.death);
        Instantiate(explosionPrefab, transform.position, Quaternion.Euler(0,0, Random.Range(0, 360)));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
        PlayerStats stats = collision.GetComponent<PlayerStats>();
        stats.PlayerTakeDamage(damage);
        }
    }
}
