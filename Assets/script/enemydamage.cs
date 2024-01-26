using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemydamage : MonoBehaviour {


    public float damage;
    public float damagerate;
    public float pushbackforce;

    float nextdamage;
    bool playerInrange=false;
    GameObject theplayer;
    playerHeath theplayerHeath;


	void Start () {
        nextdamage = Time.time;
        theplayer = GameObject.FindGameObjectWithTag("Player");
        theplayerHeath = theplayer.GetComponent<playerHeath>();
	}
	

	void Update () {
        if (playerInrange) Attack();
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInrange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInrange = false;
        }
    }
    void Attack()
    {
        if (nextdamage <= Time.time)
        {
            theplayerHeath.adddamage(damage);
            nextdamage = Time.time + damagerate;
           

        }
    }
 
}
