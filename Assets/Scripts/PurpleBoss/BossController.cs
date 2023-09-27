using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BossState
{
    enter,
    fire,
    special,
    death
    // REVIEW enums
}

public class BossController : MonoBehaviour
{
    [SerializeField] private BossEnter bossEnter;

    void Start()
    {

    }

    public void ChangeState(BossState state)
    {
        switch (state)
        {
            case BossState.enter:
                bossEnter.RunState();
                break;
            case BossState.fire:
                Debug.Log("Do smth");
                break;
            case BossState.special:
                Debug.Log("Do smth");
                break;
            case BossState.death:
                Debug.Log("Do smth");
                break;
        }
    }
}
