using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float health;

    [SerializeField] private Image healthFill;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private Animator anim;

    private bool canPlayAnim = true;

    void Start()
    {
        health = maxHealth;
        healthFill.fillAmount = health / maxHealth;
        EndGameManager.endManager.gameOver = false;
    }

    public void PlayerTakeDamage(float damage)
    {
        health -= damage;
        healthFill.fillAmount = health / maxHealth;
        if (canPlayAnim)
        {
            anim.SetTrigger("Damage");
            StartCoroutine(AntiSpamAnimation());
        }
        if (health <= 0)
        {
            EndGameManager.endManager.gameOver = true;
            EndGameManager.endManager.StartResolveSequence();
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private IEnumerator AntiSpamAnimation()
    {
        canPlayAnim = false;
        yield return new WaitForSeconds(0.15f);
        canPlayAnim = true;
    }

    public void AddHealth(int healAmount)
    {
        health += healAmount;
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
        healthFill.fillAmount = health / maxHealth;
    }
}
