using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsController : MonoBehaviour
{
    public Text coinText;
    public int currentCoins = 0;
    public GameObject CoinsNow;
    private CoinsValue coins;


    public Text coinTextStore;

    void Start()
    {
        coins = CoinsNow.GetComponent<CoinsValue>();
    }
    void Update()
    {
        currentCoins = coins.currentCoins;
        coinText.text = currentCoins.ToString();
        coinTextStore.text = currentCoins.ToString();
    }
}
