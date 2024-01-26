using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
	public float aliveTime;


	void Awake()
	{
		Destroy(gameObject, aliveTime);
	}
}
	