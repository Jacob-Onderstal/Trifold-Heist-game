using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float projectileLife = 3;
    public int damageAmount = 1;

    void Start()
    {
        Destroy(gameObject, projectileLife);
    }

    private void OnCollisionEnter(Collision collision)
    {
        EnemySTATS targetHit = collision.gameObject.GetComponent<EnemySTATS>();
        if (targetHit != null)
        {
            Debug.Log("HIT!!!!");
            targetHit.Damage(damageAmount);
        }

        Destroy(gameObject);
    }
}