using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;


public class GameManager : MonoBehaviour
{
    public GameObject[] Enemies;
    public GameObject MissionCompletedUI;

    public EventReference endGame;
    private EventInstance endInstance;
    private bool isTriggered = false;
    private void Update()
    {
        if (!(Enemies[0] || Enemies[1] || Enemies[2]))
        {
            if(!isTriggered)
            {
                isTriggered = true;
                endInstance = RuntimeManager.CreateInstance(endGame);
                endInstance.start();
                MissionCompletedUI.SetActive(true);
            }
        }
    }
}
