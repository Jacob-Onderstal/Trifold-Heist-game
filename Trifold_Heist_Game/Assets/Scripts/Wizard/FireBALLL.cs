using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBALLL : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform spawnTransfrom;
    public float force = 500;

    [SerializeField] private float ShootCooldown = 1f;

    [SerializeField] private float damageTimer = 0f;

    void Update()
    {
        if (damageTimer > 0f)
        {
            damageTimer -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire1") && damageTimer <= 0f)
        {
            GameObject newProjectile = Instantiate(projectilePrefab, spawnTransfrom.position, spawnTransfrom.rotation);
            newProjectile.GetComponent<Rigidbody>().AddForce(newProjectile.transform.forward * force);
            damageTimer = ShootCooldown;
        }

    }
}