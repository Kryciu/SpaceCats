using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] 
    private float speed = 5.0f;
    
    [HideInInspector]
    public float damage;

    private void Start()
    {
        //Destroy laser if didn't hit anything
        Destroy(gameObject,5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        //When hit, deal damage
        if (!other.CompareTag("Asteroid")) return;
        var asteroid = other.GetComponent<Asteroid>();
        asteroid.TakeDamage(damage);
        Debug.Log(damage);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
