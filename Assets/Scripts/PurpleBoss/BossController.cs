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
    [SerializeField] private bool test;
    [SerializeField] private BossState testState;

    [SerializeField] private BossEnter bossEnter;
    [SerializeField] private BossFire bossFire;
    [SerializeField] private BossSpecial bossSpecial;
    [SerializeField] private BossDeath bossDeath;

    void Start()
    {
        if (test)
        {
            ChangeState(testState);
        }
    }

    public void ChangeState(BossState state)
    {
        switch (state)
        {
            case BossState.enter:
                bossEnter.RunState();
                break;
            case BossState.fire:
                bossFire.RunState();
                break;
            case BossState.special:
                bossSpecial.RunState();
                break;
            case BossState.death:
                bossEnter.StopState();
                bossFire.StopState();
                bossSpecial.StopState();
                bossDeath.RunState();
                break;
        }
    }
}
