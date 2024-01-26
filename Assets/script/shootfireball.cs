using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootfireball : MonoBehaviour {
    public float damage;
    public float speed;
    Rigidbody myRB;



	void Start () {
        myRB = GetComponentInParent<Rigidbody>();
        if (transform.rotation.y > 0) myRB.AddForce(Vector3.right * speed,ForceMode.Impulse);
        else myRB.AddForce(Vector3.right * - speed, ForceMode.Impulse);
    }
	

    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="enemy" || other.gameObject.layer== LayerMask.NameToLayer("shootable"))
        {
            myRB.velocity = Vector3.zero;
            zombieheath zombieheath = other.GetComponent<zombieheath>();
            if(zombieheath != null)
            {
                zombieheath.adddamage(damage);
                zombieheath.addfire();
            }
            Destroy(gameObject);
        }
    }
}
