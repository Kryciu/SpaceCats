using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    private int CurrentHealthLevel;
    private int CurrentPowerLevel;
    private int CurrentSpeedLevel;

    private void Awake()
    {
        CurrentHealthLevel = PlayerPrefs.GetInt("HealthLevel");
        CurrentPowerLevel = PlayerPrefs.GetInt("PowerLevel");
        CurrentPowerLevel = PlayerPrefs.GetInt("SpeedLevel");
    }
    public void HealthUpgrade()
    {
        CurrentHealthLevel = 1;
        PlayerPrefs.SetInt("HealthLevel", CurrentHealthLevel);
        PlayerPrefs.Save();
    }

    public void PowerUpgrade()
    {
        CurrentPowerLevel = 1;
        PlayerPrefs.SetInt("HealthLevel", CurrentPowerLevel);
        PlayerPrefs.Save();
    }

    public void SpeedUpgrade()
    {
        CurrentSpeedLevel = 1;
        PlayerPrefs.SetInt("HealthLevel", CurrentSpeedLevel);
        PlayerPrefs.Save();
    }
}
