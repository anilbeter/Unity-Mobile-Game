using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private int hitToDestroy = 3;
    public bool protection = false;

    [SerializeField] private GameObject[] shieldBase;

    private void OnEnable()
    {
        hitToDestroy = 3;
        for (int i = 0; i < shieldBase.Length; i++)
        {
            shieldBase[i].SetActive(true);
        }
        protection = true;
    }

    private void UpdateUI()
    {
        switch (hitToDestroy)
        {
            case 0:
                for (int i = 0; i < shieldBase.Length; i++)
                {
                    shieldBase[i].SetActive(false);
                }
                break;
            case 1:
                shieldBase[0].SetActive(true);
                shieldBase[1].SetActive(false);
                shieldBase[2].SetActive(false);
                break;
            case 2:
                shieldBase[0].SetActive(true);
                shieldBase[1].SetActive(true);
                shieldBase[2].SetActive(false);
                break;
            case 3:
                shieldBase[0].SetActive(true);
                shieldBase[1].SetActive(true);
                shieldBase[2].SetActive(true);
                break;
            default:
                Debug.Log("We don't have this case, something should be wrong");
                break;
        }

    }

    private void DamageShield()
    {
        hitToDestroy -= 1;
        if (hitToDestroy <= 0)
        {
            hitToDestroy = 0;
            protection = false;
            gameObject.SetActive(false);
        }
        UpdateUI();
    }

    public void RepairShield()
    {
        hitToDestroy = 3;
        UpdateUI();
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
