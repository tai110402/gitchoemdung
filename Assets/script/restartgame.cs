using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restartgame : MonoBehaviour {

    public float restarttime;
    bool resetNow = false;
    float resettime;
	
	
	void Update () {
		if(resetNow && resettime <= Time.time)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
	}
    public void restartGame()
    {
        resetNow = true;
        resettime = restarttime + Time.time;
    }
    public void exitgame()
    {
        Application.Quit();
    }
}
