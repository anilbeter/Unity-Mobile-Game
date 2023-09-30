using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpShooting : MonoBehaviour
{
    [SerializeField] private AudioClip shootingPowerSound;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShooting player = other.GetComponent<PlayerShooting>();
            player.IncreaseUpgrade(1);
            AudioSource.PlayClipAtPoint(shootingPowerSound, transform.position, 1f);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
