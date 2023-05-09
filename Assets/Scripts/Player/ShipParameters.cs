using UnityEngine;

public class ShipParameters : MonoBehaviour, IDamagable
{
    [Header("Ship Stats")]
    public ShipStats shipStats;

    public void DealDamage(float damage)
    {
        shipStats.health -= damage;
        if (shipStats.health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
