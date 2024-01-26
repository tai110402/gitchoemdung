using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomappear : MonoBehaviour {

    public Material[] zombiematerials;

	
	void Start () {
        SkinnedMeshRenderer myrender = GetComponent<SkinnedMeshRenderer>();
        myrender.material = zombiematerials[Random.Range(0,zombiematerials.Length)];


	}
	

}
