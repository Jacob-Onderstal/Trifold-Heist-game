using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSTAST : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int MAXhealth;

    [SerializeField] protected bool isDead;

    private void Start()
    {
        IntVariables();
    }

    public virtual void CheckHealth()
    {
        if (health <= 0)
        {
            health = 0;
            Die();
            if (isDead == true)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene(2);
            }
        }

        if (health >= MAXhealth)
        {
            health = MAXhealth;
        }
    }

    public virtual void Die()
    {
        isDead = true;
    }

    public bool IsDeadCheck()
    {
        return isDead;
    }

    public void SetHealthTo(int HealthToSetTo)
    {
        health = HealthToSetTo;
        CheckHealth();
    }

    public void TakeDamage(int damage)
    {
        int healthAfterDamage = health - damage;
        SetHealthTo(healthAfterDamage);
    }

    public void Heal(int heal)
    {
        int HealthAfterHeal = health + heal;
        SetHealthTo(HealthAfterHeal);
    }

    public void IntVariables()
    {
        MAXhealth = 100;
        SetHealthTo(MAXhealth);
        isDead = false;
    }
}
