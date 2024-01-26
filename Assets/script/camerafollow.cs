using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour {
    public Transform target;
    public float smooth = 6f;
    Vector3 offset; // khoang cach giua camera va nhan vat

    
    
	void Start () {
        offset = transform.position - target.position;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 targetCampos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCampos, smooth * Time.deltaTime);
	}
}
