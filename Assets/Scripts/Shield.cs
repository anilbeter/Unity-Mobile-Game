using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private int hitToDestroy = 3;
    public bool protection = false;

    private void OnEnable()
    {
        hitToDestroy = 3;
        protection = true;
    }

    private void DamageShield()
    {
        hitToDestroy -= 1;
        if (hitToDestroy <= 0)
        {
            protection = false;
            gameObject.SetActive(false);
        }
    }

    public void RepairShield()
    {
        hitToDestroy = 3;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(10000);
            DamageShield();
        }
        else
        {
            Destroy(other.gameObject);
            DamageShield();
        }
    }
}
