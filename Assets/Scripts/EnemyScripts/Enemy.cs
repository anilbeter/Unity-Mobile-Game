using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // protected -> visible just to parent and child classes. Other classes can't see or change them directly
    [SerializeField] protected float health;


    void Start()
    {

    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        // damage animation
        if (health <= 0)
        {
            // destroy animation
        }
    }
}
