using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsController : MonoBehaviour
{
    public Text coinText;
    public int currentCoins = 0;


    void Update()
    {
        coinText.text = currentCoins.ToString();
    }
}
