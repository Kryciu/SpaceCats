using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class CoinCounter : MonoBehaviour
{
    public TextMeshPro coinText;
    public static int coins;

    void Start()
    {
        coins = PlayerPrefs.GetInt("CoinsAmount");
        coinText = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        coinText.text = coins.ToString();
    }
}
