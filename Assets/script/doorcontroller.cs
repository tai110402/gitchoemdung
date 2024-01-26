using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class doorcontroller : MonoBehaviour {

    public Text thongbao;
    public restartgame gamecontrol;
    AudioSource safehouseaudio;
    bool insafe = false;
    // Use this for initialization
    void Start () {
        safehouseaudio = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	
    void OnTriggerEnter(Collider other)
    {
        if(other.tag== "Player" && insafe==false)
        {
            Animator dooranim = GetComponentInChildren<Animator>();
            dooranim.SetTrigger("safehouse");
            safehouseaudio.Play();
            thongbao.text = "Safe House";
            Animator endanim = thongbao.GetComponent<Animator>();
            endanim.SetTrigger("gamover");
            gamecontrol.restartGame();
            insafe = true;
        }
    }
}
