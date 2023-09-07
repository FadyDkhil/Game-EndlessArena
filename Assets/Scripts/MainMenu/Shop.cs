using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private GameObject stats;
    private PlayerStats playerStats;
    public Text SwordLevelText;
    private int slevel = 1;
    public Text ArmorLevelText;
    private int alevel = 1;

    public Text SwordMoney;
    public Text ArmorMoney;

    public GameObject CV;
    private CoinsValue coins;

    void Awake()
    {
        alevel = 1;
        slevel = 1;
    }
    void Start()
    {
        coins = CV.GetComponent<CoinsValue>();
        stats = GameObject.FindGameObjectWithTag("PlayerStats");
        playerStats = stats.GetComponent<PlayerStats>();
        SwordMoney.text = (slevel*5).ToString();
        ArmorMoney.text = (alevel*5).ToString();
    }

    public void SwordUpgrade()
    {
        if(coins.currentCoins >= slevel * 5){
        coins.currentCoins -= slevel * 5;
        playerStats.attackDamage += (playerStats.attackDamage * 0.1f);
        slevel++;
        SwordMoney.text = (slevel*5).ToString();
        SwordLevelText.text = "Level " + slevel.ToString();
        }
    }

    public void ArmorUpgrade()
    {
        if(coins.currentCoins >= alevel * 5){
        coins.currentCoins -= alevel * 5;
        playerStats.maxHealth += (playerStats.maxHealth * 0.1f);
        alevel++;
        ArmorMoney.text = (alevel*5).ToString();
        ArmorLevelText.text = "Level " + alevel.ToString();
        }

    }
}
