using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShieldActivator : MonoBehaviour
{
    [SerializeField] private Shield shield;

    public void ActivateShield()
    {
        // is shield already active or not?
        if (!shield.gameObject.activeSelf)
        {
            shield.gameObject.SetActive(true);
        }
        else
        {
            shield.RepairShield();
        }
    }

}
