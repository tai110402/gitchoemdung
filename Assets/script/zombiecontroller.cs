using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombiecontroller : MonoBehaviour {

    public GameObject flipmodel;
    public AudioClip[] idlesound;
    public float idlesoundtime;
    AudioSource enemymovement;
    float nextidlesound = 0f;
    public float detectTime;
    float startrun;
    bool firstdetection;
    //move option

    public float runspeed;
    public float walkspeed;
    public bool facingright = true;
    float movespeed;
    bool running;
    Rigidbody myRB;
    Animator myAnim;
    Transform detectedplayer;
    public GameObject ragdolldead;
    bool detected;
	// Use this for initialization
	void Start () {
        myRB = GetComponentInParent<Rigidbody>();
        myAnim = GetComponentInParent<Animator>();
        enemymovement = GetComponent<AudioSource>();
        running = false;
        detected = false;
        firstdetection = false;
        movespeed = walkspeed;

        if (Random.Range(0, 10) > 5) Flip();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (detected)
        {
            if (detectedplayer.position.x < transform.position.x && facingright) Flip();
         
            else if (detectedplayer.position.x > transform.position.x && !facingright) Flip();
            if (!firstdetection)
            {
                startrun = Time.time + detectTime;
                firstdetection = true;
            }
        }
        if(detected && !facingright)
        {
            myRB.velocity = new Vector3((movespeed * -1), myRB.velocity.y,0);

        }
        else if (detected && facingright)
        {
            myRB.velocity = new Vector3(movespeed, myRB.velocity.y, 0);

        }
        if(!running && detected)
        {
            if(startrun< Time.time)
            {
                movespeed = runspeed;
                myAnim.SetTrigger("run");
                running = true;
            }
        }
        if (!running)
        {
            if(Random.Range(0,10)>5 && nextidlesound < Time.time)
            {
                AudioClip temclip = idlesound[Random.Range(0, idlesound.Length)];
                enemymovement.clip = temclip;
                enemymovement.Play();
                nextidlesound = idlesoundtime + Time.time;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player" && !detected)
        {
            detected = true;
            detectedplayer = other.transform;
            myAnim.SetBool("dtected", detected);
            if (detectedplayer.position.x < transform.position.x && facingright)
            {
                Flip();
            }
            else if (detectedplayer.position.x > transform.position.x && !facingright) Flip();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            firstdetection = false;
            if (running)
            {
                myAnim.SetTrigger("run");
                movespeed = walkspeed;
                running = false;
            }
        }
    }
    void Flip()
    {
        facingright = !facingright;
        Vector3 thescale = flipmodel.transform.localScale;
        thescale.z *= -1;
        flipmodel.transform.localScale = thescale;
    }
    public void ragdollDeath()
    {
        GameObject ragdoll = Instantiate(ragdolldead, transform.root.position, Quaternion.identity) as GameObject;

        Transform ragdollmaster = ragdoll.transform.Find("master");
        Transform zombiemaster = transform.root.Find("master");
        bool wasfacingright = true;
        if (!facingright)
        {
            wasfacingright = false;
            Flip();
            
        }
        Transform [] ragdollJoints = ragdollmaster.GetComponentsInChildren<Transform>();
        Transform [] currentjoin = zombiemaster.GetComponentsInChildren<Transform>();

        for(int i=0;i< ragdollJoints.Length; i++)
        {
            for(int q=0;q< currentjoin.Length; q++)
            {
                if (currentjoin[q].name.CompareTo(ragdollJoints[i].name) == 0)
                {
                    ragdollJoints[i].position = currentjoin[q].position;
                    ragdollJoints[i].rotation = currentjoin[q].rotation;
                    break;
                }
            }
        }

        if (wasfacingright)
        {
            Vector3 rotvector = new Vector3(0, 0, 0);
            ragdoll.transform.rotation = Quaternion.Euler(rotvector);
        }
        else
        {
            Vector3 rotvector = new Vector3(0, 90, 0);
            ragdoll.transform.rotation = Quaternion.Euler(rotvector);
        }
        Transform zombirmesh = transform.root.transform.Find("zombieSoldier");
        Transform ragdollmesh = ragdoll.transform.Find("zombieSoldier");
        ragdollmesh.GetComponent<Renderer>().material = zombirmesh.GetComponent<Renderer>().material;
    }
}
