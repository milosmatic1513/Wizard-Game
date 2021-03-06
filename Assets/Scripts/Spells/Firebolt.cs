﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebolt : Spell
{
    [SerializeField]
    private float damage = 15f;
    [SerializeField]
    private float speed = 8f;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private GameObject explosionParticles;

    private Transform firePoint;

    public override void FireSimple()
    {
        GameObject tmp = Instantiate(gameObject, firePoint.position, firePoint.rotation) as GameObject;
        Destroy(tmp, 5f);
    }

    public override void SetFirePoint(Transform point)
    {
        firePoint = point;
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward * speed * Time.deltaTime, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Damageable"))
            collision.transform.SendMessage("Damage", damage);
        Destroy(Instantiate(explosionParticles, transform.position, transform.rotation), 1f);
        Destroy(gameObject);
    }

    public override void FireHold(bool holding)
    {
    }

    public override void WakeUp()
    {
    }
}
