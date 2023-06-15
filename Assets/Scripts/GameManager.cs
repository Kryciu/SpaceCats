using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Enemies;
    private void Update()
    {
        if (!(Enemies[0] || Enemies[1] || Enemies[2]))
        {
            Debug.Log("Mission Completed");
        }
    }
}
