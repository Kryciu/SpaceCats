using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public bool isSpawn = false;

    IEnumerator unSpawn()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (isSpawn == true)
        {
            StartCoroutine(unSpawn());
        }
        else
        {
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
