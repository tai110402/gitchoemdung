using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {
    public Light explosionlight;
    public float power;
    public float radius;
    public float damage;


	void Start () {
        Vector3 explosion = transform.position;
        Collider[] collide = Physics.OverlapSphere(explosion, radius);
        foreach(Collider hit in collide)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(power, explosion,radius,3.0f,ForceMode.Impulse);
                if (hit.tag == "Player")
                {
                    playerHeath playerheath = hit.gameObject.GetComponent<playerHeath>();
                    playerheath.adddamage(damage);
                }else if (hit.tag == "enemy")
                {
                    zombieheath zombiehel = hit.gameObject.GetComponent<zombieheath>();
                    zombiehel.adddamage(damage);
                }
            }
        }
	}
	

	void Update () {
        explosionlight.intensity = Mathf.Lerp(explosionlight.intensity, 0f, 6 * Time.time);
	}
}
