using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    private GameObject player;
    private PlayerController pc;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
    }
    private void OnTriggerEnter(Collider col)
    {
        if( col.tag == "Player")
        {
            pc.Heal(10f);
            Debug.Log("Health + 10");
            Destroy(this.gameObject);
        }
    }
}