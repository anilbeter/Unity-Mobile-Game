using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // protected -> visible just to parent and child classes. Other classes can't see or change them directly
    [SerializeField] protected float health;
    [SerializeField] protected Rigidbody2D rb;

    [SerializeField] protected float damage;
    [SerializeField] protected GameObject explosionPrefab;


    void Start()
    {

    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        HurtSequence();
        if (health <= 0)
        {
            DeathSequence();
        }
    }

    // virtual functions -> can be use and override by child classes
    public virtual void HurtSequence()
    {
        // do something
    }

    public virtual void DeathSequence()
    {
        // do something
    }
}
