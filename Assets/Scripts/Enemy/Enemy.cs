using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = FMOD.Debug;

public class Enemy : MonoBehaviour, IDamagable
{
    public EnemyData EnemyData;
    
    private float maxHealth = 100;
    private float currentHealh;
    
    private Rigidbody _rb;

    public List<GameObject> checkpoint = new List<GameObject>();
    private bool Cycle = false;
    public int i = 0;
    public float speed = 10;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealh = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, checkpoint[i].transform.position, step);
        if (transform.position == checkpoint[i].transform.position)
        {
            if (i + 1 == checkpoint.Count)
            {
                i = -1;
            }
            i++;

        }
    }

    public void DealDamage(float damage)
    {
        currentHealh -= damage;
        if (EnemyData.Health <= 0)
        {
            DestroyObject();
        }
    }

    public void DestroyObject()
    {
        throw new System.NotImplementedException();
    }

    private void move()
    {
        Cycle = true;
        if (i <= checkpoint.Count)
        {
            i++;
        }
        else
        {
            i = 0;
            Cycle = false;
        }
    }
}
