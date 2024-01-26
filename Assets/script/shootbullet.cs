using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootbullet : MonoBehaviour {

    // Use this for initialization
    public float range = 12f;
    public float damage = 30f;
    Ray shootray;
    RaycastHit shoothit;
    int shootableMask;
    LineRenderer gunline;

    void Awake() {
        shootableMask = LayerMask.GetMask("shootable");
        gunline = GetComponent<LineRenderer>();
        shootray.origin = transform.position;
        shootray.direction = transform.forward;
        gunline.SetPosition(0,transform.position);
        if (Physics.Raycast(shootray, out shoothit, range, shootableMask))
        {
            if (shoothit.collider.tag == "enemy")
            {
                zombieheath zombieheath = shoothit.collider.GetComponent<zombieheath>();
                if(zombieheath != null)
                {
                    zombieheath.adddamage(damage);
                    zombieheath.damageFX(shoothit.point, -shootray.direction);
                }
            }
            //ban va va cham voi enemy

            gunline.SetPosition(1, shoothit.point);

        }
        else gunline.SetPosition(1, shootray.origin + shootray.direction * range);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
