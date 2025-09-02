using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySTATS : CharacterSTAST
{
    public int maxHealth = 3;
    protected int currentHealth;

    void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public virtual void Damage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
