using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gragedoor : MonoBehaviour {
    public bool reset;
    public GameObject door;
    public GameObject gear;
    public bool startopen;
    bool firsttrigger = false;
    bool open = true;
    Animator doorAnim;
    Animator gearAnim;
    AudioSource dooradio;

	void Start () {
        doorAnim = door.GetComponent<Animator>();
        gearAnim = gear.GetComponent<Animator>();
        dooradio = door.GetComponent<AudioSource>();
        if (!startopen)
        {
            open = false;
            doorAnim.SetTrigger("doortrigger");
            dooradio.Play();
            
        
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !firsttrigger)
        {
            if (!reset) firsttrigger = true;
            doorAnim.SetTrigger("doortrigger");
            open = !open;
            gearAnim.SetTrigger("geartrigger");
            dooradio.Play();
        }
       
    }

}
