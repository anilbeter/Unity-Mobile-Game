using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PurpleEnemy : Enemy
{
    [SerializeField] private float speed;

    private float shootTimer = 0;
    [SerializeField] private float shootInterval;

    [SerializeField] private Transform leftCannon;
    [SerializeField] private Transform rightCannon;

    [SerializeField] private GameObject bulletPrefab;

    void Start()
    {
        rb.velocity = Vector2.down * speed;
    }


    void Update()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            Instantiate(bulletPrefab, leftCannon.position, Quaternion.identity);
            Instantiate(bulletPrefab, rightCannon.position, Quaternion.identity);
            shootTimer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // damage variable is inherited from parent class
            other.GetComponent<PlayerStats>().PlayerTakeDamage(damage);
            // explosionPrefab variable is inherited from parent class
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public override void HurtSequence()
    {
        // GetCurrentAnimatorStateInfo(0) -> 0 means that is Base Layer
        // if condition means -> animation currently running
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Dmg"))
            return;
        // So; if animation is running, just return. Don't activate it one more time. I use it for anti-spam
        anim.SetTrigger("Damage");
    }

    public override void DeathSequence()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
