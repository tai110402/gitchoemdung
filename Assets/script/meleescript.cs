using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleescript : MonoBehaviour {
    public float damage;
    public float knockback;
    public float knockradius;
    public float meleerate;
    float nextmelee;
    int shootableMask;
    Animator myanim;
    playerController myPC;
	
	void Start () {
        shootableMask = LayerMask.GetMask("shootable");
        myanim = transform.root.GetComponent<Animator>();
        myPC = transform.root.GetComponent<playerController>();
        nextmelee = 0f;
	}
	
	
	void FixedUpdate () {
        float melee = Input.GetAxis("Fire2");
        if(melee>0 && nextmelee<Time.time && !(myPC.getrunning()))
        {
            myanim.SetTrigger("gunmelee");
            nextmelee = Time.time + meleerate;

            Collider[] attacked = Physics.OverlapSphere(transform.position, knockradius, shootableMask);
            int i = 0;
            while(i< attacked.Length)
            {
                if (attacked[i].tag == "enemy")
                {
                    zombieheath makedamage = attacked[i].GetComponent<zombieheath>();
                    makedamage.adddamage(damage);
                    makedamage.damageFX(transform.position, transform.localEulerAngles);
                }
                i++;
            }

        }
	}
}
