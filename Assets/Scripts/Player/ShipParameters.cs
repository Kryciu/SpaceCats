using UnityEngine;
using FMODUnity;
using FMOD.Studio;


public class ShipParameters : MonoBehaviour, IDamagable
{
    [Header("Ship Stats")]
    public ShipStats shipStats;


    private string eventNameShipDestroy = "event:/spaceship destroyed";
    EventInstance shipDestroyAudio;
    private Camera _playerCamera;


    private void Awake()
    {
        _playerCamera = Camera.main;
        if (PlayerPrefs.GetInt("HealthLevel") == 0)
        {
            shipStats = Resources.Load<ShipStats>("DefaultShipStats");
        } else
        {
            shipStats = Resources.Load<ShipStats>("UpgradedShipStats");
        }
    }

    public void TakeDamage(float damage)
    {
        shipStats.health -= damage;
        if (shipStats.health <= 0)
        {
            shipDestroyAudio = RuntimeManager.CreateInstance(eventNameShipDestroy);
            shipDestroyAudio.set3DAttributes(RuntimeUtils.To3DAttributes(_playerCamera.transform.position));
            shipDestroyAudio.start();
            Destroy(gameObject);
            
        }
    }
}
