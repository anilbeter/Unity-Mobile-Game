using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFire : BossBaseState
{
    [SerializeField] private float speed;
    [SerializeField] private float shootRate;
    [SerializeField] private GameObject bulletPrefeb;
    [Header("Shooting Points")]
    [SerializeField]
    private Transform[] shootingPoint;

    public override void RunState()
    {
        StartCoroutine(RunFireState());
    }

    public override void StopState()
    {
        base.StopState();
    }

    IEnumerator RunFireState()
    {
        float shootTimer = 0f;
        float fireStateTimer = 0f;
        float fireStateExitTime = Random.Range(5f, 10f);
        Vector2 targetPosition = new Vector2(Random.Range(maxLeft, maxRight), Random.Range(maxDown, maxUp));
        while (fireStateTimer <= fireStateExitTime)
        {
            if (Vector2.Distance(transform.position, targetPosition) > 0.01f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
            else
            {
                targetPosition = new Vector2(Random.Range(maxLeft, maxRight), Random.Range(maxDown, maxUp));
            }
            shootTimer += Time.deltaTime;
            if (shootTimer >= shootRate)
            {
                for (int i = 0; i < shootingPoint.Length; i++)
                {
                    Instantiate(bulletPrefeb, shootingPoint[i].position, Quaternion.identity);
                }
                shootTimer = 0;
            }
            yield return new WaitForEndOfFrame();
            fireStateTimer += Time.deltaTime;
        }
    }
}
