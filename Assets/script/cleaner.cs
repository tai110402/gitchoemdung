using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleaner : MonoBehaviour {



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" )
        {
            playerHeath playerFall = other.gameObject.GetComponent<playerHeath>();
            playerFall.makeDeath();
           
        }
        else if (other.tag == "enemy")
        {
            zombieheath zombiefall = other.gameObject.GetComponent<zombieheath>();
            zombiefall.makedead();


        }

    }
}
