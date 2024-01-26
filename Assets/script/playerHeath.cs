using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHeath : MonoBehaviour
{
    public float fullmau;
    float currentmau;
    public GameObject playerDeadFX;

    //link to slider
    public Slider playerheathSlider;
    public Image damagescreen;
    Color flashColor = new Color(255f, 255f, 255f, 1f);
    float flashspeed = 5f;
    bool damaged = false;
    AudioSource playerAS;

    public Text thongbao;
    public restartgame gamecontrol;


    // Use this for initialization
    void Awake()
    {
        currentmau = fullmau;
        playerheathSlider.maxValue = fullmau;
        playerheathSlider.value = currentmau;
        playerAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
            damagescreen.color = flashColor;
        }
        else
        {
            damagescreen.color = Color.Lerp(damagescreen.color, Color.clear, flashspeed * Time.deltaTime);
        }
        damaged = false;
    }
    public void adddamage(float damage)
    {
        currentmau -= damage;
        playerheathSlider.value = currentmau;
        damaged = true;
        playerAS.Play();
        if (currentmau <= 0)
        {
            makeDeath();
        }
    }
    public void addheath(float heath)
    {
        currentmau += heath;
        if (currentmau > fullmau) currentmau = fullmau;
        playerheathSlider.value = currentmau;
    }
    public void makeDeath()
    {
        Instantiate(playerDeadFX, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
        damagescreen.color = flashColor;
        Destroy(gameObject);
        Animator endanim = thongbao.GetComponent<Animator>();
        endanim.SetTrigger("gamover");
        gamecontrol.restartGame();
    }
}
