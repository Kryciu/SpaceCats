using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class CollectingCoins : MonoBehaviour
     
{
    private string CollectingCoin = "event:/lvl/coin";
    EventInstance CoinCollecting;
    private Camera _playerCamera;
    
    void Start()
    {
        CoinCollecting = RuntimeManager.CreateInstance(CollectingCoin);
        _playerCamera = Camera.main;
    }

    public void OnTriggerEnter(Collider Col)
    {
        
        if (Col.gameObject.tag == "Coin")
        {

            CoinCollecting.set3DAttributes(RuntimeUtils.To3DAttributes(_playerCamera.transform.position));
            CoinCollecting.start();
            Debug.Log("Coin collected");
            CoinCounter.coins += 1;
            PlayerPrefs.SetInt("CoinsAmount",CoinCounter.coins);
            PlayerPrefs.Save();
            // Col.gameObject.SetActive(false);
            Destroy(Col.gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
