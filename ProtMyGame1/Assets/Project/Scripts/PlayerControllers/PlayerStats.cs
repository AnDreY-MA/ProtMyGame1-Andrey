using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private GameObject deathChunkParticle, deathBloodParticle;

    private float currentHealth;

    private GameManager gameManag;

    private void Start()
    {
        currentHealth = maxHealth;
        gameManag = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    //Получение урона
    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            Die();
        }

    }

    private void Die()
    {
        Instantiate(deathChunkParticle, transform.position, deathChunkParticle.transform.rotation);
        Instantiate(deathBloodParticle, transform.position, deathBloodParticle.transform.rotation);
        gameManag.Respawn();
        Destroy(gameObject);
    }
}