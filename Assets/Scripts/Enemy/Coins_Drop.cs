using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Coins_Drop : MonoBehaviour
{
    public EnemyData EnemyData;
    public GameObject coinPrefab;
    public int coinCount = 5;

    private bool isDead = false;
    private float maxHealth;
    public float currentHealth;
    private Coin CoinScript;

    public void DieCoins()
    {
        if (!isDead)
        {
            isDead = true;

            for (int i = 0; i < coinCount; i++)
            {
                GameObject coin = Instantiate(coinPrefab, transform.position, quaternion.identity);
                coin.transform.position += new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
                CoinScript = coin.GetComponent<Coin>();
                CoinScript.isSpawn = true;
            }
        }
    }
    
    
    // Start is called before the first frame update
    private void Start()
    { 
        currentHealth = EnemyData.maxHealth;
    }

    public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

       private void Die()
        {
            Destroy(gameObject);
            DieCoins();
        }


}
