using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Laser : MonoBehaviour
{
    [SerializeField] 
    private float speed = 5.0f;
    
    [HideInInspector]
    public float damage;

    private void Start()
    {
        //Destroy laser if didn't hit anything
        Destroy(gameObject,1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        //When hit, deal damage
        IDamagable damagable = other.GetComponentInParent<IDamagable>();
        if (damagable == null) return;
        damagable.TakeDamage(damage);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
