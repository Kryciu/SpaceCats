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
    }

    public void DealDamage(float damage)
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
