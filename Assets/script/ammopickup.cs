using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammopickup : MonoBehaviour {


	
	
    void OnTriggerEnter(Collider other)
    {
       if( other.tag== "Player")
        {
            other.GetComponentInChildren<firebullet>().reload();


            Destroy(transform.root.gameObject);
			
        }
    }
}
