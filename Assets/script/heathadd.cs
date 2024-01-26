using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heathadd : MonoBehaviour {
    public float heathAmount;
    public AudioClip sound;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<playerHeath>().addheath(heathAmount);
            Destroy(transform.root.gameObject);
            AudioSource.PlayClipAtPoint(sound, transform.position, 1.5f);
        }
    }
}
