using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorcontroller : MonoBehaviour
{
    public float resettime;

    Animator anim;
    AudioSource elevAs;
    float downtime;
    bool elevup = false;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        elevAs = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (downtime <= Time.time && elevup)
        {
            anim.SetTrigger("active");
            elevup = false;
            elevAs.Play();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.SetTrigger("active");
            downtime = Time.time + resettime;
            elevup = true;
            elevAs.Play();
           
        }
    }
}
