using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponpickupcontrol : MonoBehaviour {

    public int whichWeapon;
    public AudioClip pickUpClip;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if(other.tag== "Player")
        {
            other.gameObject.GetComponent<inventorymanager>().activeweapon(whichWeapon);
            Destroy(transform.root.gameObject);
            AudioSource.PlayClipAtPoint(pickUpClip, transform.position);
        }
    }
}
