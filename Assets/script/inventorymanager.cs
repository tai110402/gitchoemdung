using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventorymanager : MonoBehaviour {

    public GameObject[] weapon;
    bool[] weaponavaiable;
    public Image weaponimage;
    int currentweapon;

	// Use this for initialization
	void Start () {
        weaponavaiable = new bool[weapon.Length];
        for (int i = 0; i < weapon.Length; i++) weaponavaiable[i] = false;
        currentweapon = 0;
        weaponavaiable[currentweapon] = true;
       
        deactiveweapon();


        setweaponactive(currentweapon);

    }
	
	
	void Update () {
        if (Input.GetButtonDown("Fire2"))
        {//an xuong de doi vu khi
            int i;
            Debug.Log("space key was pressed");
            for (i=currentweapon+1; i < weapon.Length; i++)
            {
                if (weaponavaiable[i] == true)
                {
                    currentweapon = i;
                    setweaponactive(currentweapon);
                    return;
                }
            }
            for (i = 0; i < currentweapon; i++)
            {
                if (weaponavaiable[i] == true)
                {
                    currentweapon = i;
                    setweaponactive(currentweapon);
                    return;
                }
            }
        }
	}
    public void setweaponactive(int whichweapon)
    {
        if (!weaponavaiable[whichweapon] == true) return;
        deactiveweapon();
        weapon[whichweapon].SetActive(true);
        weapon[whichweapon].GetComponentInChildren<firebullet>().iniweapon();
    }
     void deactiveweapon()
    {
        for (int i = 0; i < weapon.Length; i++) weapon[i].SetActive(false);
    }
    public void activeweapon(int whichweapon)
    {
        weaponavaiable[whichweapon] = true;
    }
}
