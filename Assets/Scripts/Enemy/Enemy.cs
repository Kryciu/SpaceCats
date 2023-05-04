using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = FMOD.Debug;

public class Enemy : MonoBehaviour, IDamagable
{
    private float maxHealth = 100;

    private float currentHealh;
    public int Distance;
    public List<GameObject> checkpoint = new List<GameObject>();
    private bool Cycle = false;
    public int i = 0;
    public float speed = 10;


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
            i++;
            if (i + 1 == checkpoint.Count)
            {
                i = 0;
            }
        }
    }

    public void DealDamage(float damage)
    {
        currentHealh -= damage;
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
