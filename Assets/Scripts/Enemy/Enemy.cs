using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Debug = FMOD.Debug;
using FMODUnity;
using FMOD.Studio;

public class Enemy : MonoBehaviour, IDamagable
{
    public EnemyData EnemyData;

    private float maxHealth;
    private float currentHealh;

    private Rigidbody _rb;

    private float speed;
    public float detectionRange = 400f;
    public GameObject Player;
    public GameObject laserPrefab;

    private int _currentCheckpointIndex;
    private Vector3 originPosition;
    private bool isStop;
    private string eventEnemyWeapons = "event:/enemy/enemy blasters";
    EventInstance EnemyWeaponsAudio;
    private Camera _playerCamera;
    private string eventEnemyDestroy = "event:/enemy/enemy";
    EventInstance EnemyDestroy;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        originPosition = transform.position;
        _playerCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealh = EnemyData.maxHealth;
        speed = EnemyData.Speed;

        isStop = false;
        EnemyWeaponsAudio = RuntimeManager.CreateInstance(eventEnemyWeapons);
    }

    IEnumerator Shooting()
    {
        while (true)
        {
            EnemyWeaponsAudio.set3DAttributes(RuntimeUtils.To3DAttributes(_playerCamera.transform.position));
            Instantiate(laserPrefab, transform.position - new Vector3(0,0,50), quaternion.identity);
            EnemyWeaponsAudio.start();
            EnemyWeaponsAudio.release();
            yield return new WaitForSeconds(.1f);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);
        
            if(isStop)
            {
                var step = EnemyData.Speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position,originPosition + EnemyData.checkpoints
                    [_currentCheckpointIndex].transform.position, 1);

                if (transform.position == originPosition + EnemyData.checkpoints[_currentCheckpointIndex].transform.position)

                {
                    _currentCheckpointIndex = (_currentCheckpointIndex + 1) % EnemyData.checkpoints.Count;
                }
            }
            else
            {
                //var step = 150 * Time.deltaTime;
                //transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, step);
                _rb.velocity = new Vector3(0, 0, (150 * -1));
                if (distanceToPlayer <= detectionRange)
                {
                    originPosition = transform.position;
                    _rb.velocity = Vector3.zero;
                    isStop = true;
                    StartCoroutine("Shooting");
                }
            }
        }
    }
    public void TakeDamage(float damage)
    {
        if (isStop)
        {
            currentHealh -= damage;
            if (currentHealh <= 0)
            {
                EnemyDestroy = RuntimeManager.CreateInstance(eventEnemyDestroy);
                EnemyDestroy.set3DAttributes(RuntimeUtils.To3DAttributes(_playerCamera.transform.position));
                EnemyDestroy.start();

                GetComponent<Coins_Drop>().DieCoins();
                Destroy(gameObject);
            }
        }
    }
}