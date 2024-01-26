using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zombieheath : MonoBehaviour {

    public float enemyMaxheath;
    public float damagemodifier;
    public GameObject damagepartical;
    public GameObject drop;
    public bool drops;
    public AudioClip deathsound;
    public bool canburn;
    public float burndamage;
    public float burntime;
    public GameObject burneffect;
    bool onfire;
    float nextburn;
    float burnInterval;
    float endburn;

    float currentheath;
    public Slider enemyheathindi;
    AudioSource enemysound;
	// Use this for initialization
	void Awake () {
        currentheath = enemyMaxheath;
        enemyheathindi.maxValue = enemyMaxheath;
        enemyheathindi.value = currentheath;
        enemysound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(onfire && Time.time> nextburn)
        {
            adddamage(burndamage);
            nextburn += burnInterval;
        }
        if(onfire && Time.time > endburn)
        {
            onfire = false;
            burneffect.SetActive(false);
        }
	}
    public void adddamage(float damage)
    {
        enemyheathindi.gameObject.SetActive(true);
        damage = damage * damagemodifier;
        if (damage <= 0f) return;
        currentheath -= damage;
        enemyheathindi.value = currentheath;
        enemysound.Play();
        if (currentheath <= 0)
        {
            makedead();
        }
    }
    public void addfire()
    {
        if (!canburn) return;
        else
        {
            onfire = true;
            burneffect.SetActive(true);
            endburn = Time.time + burntime;
            nextburn = Time.time + burnInterval;
        }
    }
    public void makedead()
    {
        zombiecontroller azombie = GetComponentInChildren<zombiecontroller>();
        if(azombie!= null)
        {
            azombie.ragdollDeath();
        }
        AudioSource.PlayClipAtPoint(deathsound, transform.position, 10f);
        Destroy(gameObject.transform.root.gameObject);
        if (drops) Instantiate(drop, transform.position, transform.rotation);
    }
    public void damageFX(Vector3 point, Vector3 rotation)
    {
        Instantiate(damagepartical, point, Quaternion.Euler(rotation));
    }
}
