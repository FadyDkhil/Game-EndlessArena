using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePowerUp : MonoBehaviour
{
    private GameObject SwordGameObject;
    private Sword sword;

    void Start()
    {
        SwordGameObject = GameObject.FindGameObjectWithTag("PlayerSword");
        sword = SwordGameObject.GetComponent<Sword>();
    }
    private void OnTriggerEnter(Collider col)
    {
        if( col.tag == "Player")
        {
            sword.DamageUp();
            Destroy(this.gameObject);
        }
    }
}
