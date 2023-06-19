using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CoinsAmount;
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject button3;
    [SerializeField] private GameObject image1;
    [SerializeField] private GameObject image2;
    [SerializeField] private GameObject image3;
    [SerializeField] private Slider ArmorSlider;
    [SerializeField] private Slider SpeedSlider;
    [SerializeField] private Slider PowerSlider;
    private int CurrentHealthLevel;
    private int CurrentPowerLevel;
    private int CurrentSpeedLevel;

    private void Awake()
    {
        CurrentHealthLevel = PlayerPrefs.GetInt("HealthLevel");
        CurrentPowerLevel = PlayerPrefs.GetInt("PowerLevel");
        CurrentPowerLevel = PlayerPrefs.GetInt("SpeedLevel");
    }

    private void Start()
    {
        UpdateCoinsAmount();
        UpdateUI();
    }

    public void HealthUpgrade()
    {
        if (PlayerPrefs.GetInt("CoinsAmount") >= 10)
        {
            button1.SetActive(false);
            image1.SetActive(true);
            ArmorSlider.value = .65f;
            PlayerPrefs.SetInt("CoinsAmount", PlayerPrefs.GetInt("CoinsAmount") - 10);
            CurrentHealthLevel = 1;
            PlayerPrefs.SetInt("HealthLevel", CurrentHealthLevel);
            PlayerPrefs.Save();
            UpdateCoinsAmount();
        }
    }

    public void PowerUpgrade()
    {
        if (PlayerPrefs.GetInt("CoinsAmount") >= 15)
        {
            button3.SetActive(false);
            image3.SetActive(true);
            PowerSlider.value = .8f;
            PlayerPrefs.SetInt("CoinsAmount", PlayerPrefs.GetInt("CoinsAmount") - 15);
            CurrentPowerLevel = 1;
            PlayerPrefs.SetInt("PowerLevel", CurrentPowerLevel);
            PlayerPrefs.Save();
            UpdateCoinsAmount();
        }
    }

    public void SpeedUpgrade()
    {
        if (PlayerPrefs.GetInt("CoinsAmount") >= 25)
        {
            button2.SetActive(false);
            image2.SetActive(true);
            SpeedSlider.value = .55f;
            PlayerPrefs.SetInt("CoinsAmount", PlayerPrefs.GetInt("CoinsAmount") - 25);
            CurrentSpeedLevel = 1;
            PlayerPrefs.SetInt("SpeedLevel", CurrentSpeedLevel);
            PlayerPrefs.Save();
            UpdateCoinsAmount();
        }
    }

    public void UpdateCoinsAmount()
    {
        CoinsAmount.SetText(PlayerPrefs.GetInt("CoinsAmount").ToString());
    }

    public void UpdateUI()
    {
        switch (PlayerPrefs.GetInt("HealthLevel"))
        {
            case 1:
                button1.SetActive(false);
                image1.SetActive(true);
                ArmorSlider.value = .65f;
                break;
            default:
                button1.SetActive(true);
                image1.SetActive(false);
                ArmorSlider.value = .25f;
                break;
        }
        switch (PlayerPrefs.GetInt("SpeedLevel"))
        {
            case 1:
                button2.SetActive(false);
                image2.SetActive(true); 
                SpeedSlider.value = .55f;
                break;
            default:
                button2.SetActive(true);
                image2.SetActive(false);
                SpeedSlider.value = .15f;
                break;
        }
        switch (PlayerPrefs.GetInt("PowerLevel"))
        {
            case 1:
                button3.SetActive(false);
                image3.SetActive(true);
                PowerSlider.value = .8f;
                break;
            default:
                button3.SetActive(true);
                image3.SetActive(false);
                PowerSlider.value = .3f;
                break;
        }
    }
}
