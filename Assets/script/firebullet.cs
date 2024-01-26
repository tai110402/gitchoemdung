using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class firebullet : MonoBehaviour {
    public float timeForNextbullet = 0.13f;
    public GameObject projectile;
    float nextbullet;
    public Slider bullercount;
    // dan info
    public int maxbround;
    public int strartbround;
    int remainbround;

    AudioSource  gunfire;
    public AudioClip shootsound;
    public AudioClip reloadsound;

    // change weapon
    public Sprite weaponsprite;
    public Image weaponimage;



	// Use this for initialization
	void Awake () {
        nextbullet = 0f;
        remainbround = strartbround;
        bullercount.maxValue = maxbround;
        bullercount.value = remainbround;
        gunfire = GetComponent<AudioSource>();


	}
	
	// Update is called once per frame
	void Update () {
        playerController myplayer = transform.root.GetComponent<playerController>();
        if(Input.GetAxisRaw("Fire1")>0 && nextbullet < Time.time && remainbround>0)
        {
            nextbullet = Time.time + timeForNextbullet;
            Vector3 rot;
            
            if (myplayer.facing() == -1f)
            {
             rot = new Vector3(0, -90, 0);
            }
            else rot = new Vector3(0, 90, 0);
            Instantiate(projectile, transform.position, Quaternion.Euler(rot));

            playsound(shootsound);
            


            remainbround -= 1;
            bullercount.value = remainbround;
        }
	}
    public void reload()
    {
        remainbround = maxbround;
        bullercount.value = remainbround;
        playsound(reloadsound);


    }
    void playsound(AudioClip playsound)
    {
        gunfire.clip = playsound;
        gunfire.Play();
    }
    public void iniweapon()
    {
        gunfire.clip = reloadsound;
        gunfire.Play();
        nextbullet = 0;
        bullercount.maxValue = maxbround;
        bullercount.value = remainbround;
        weaponimage.sprite = weaponsprite;

    }
}
