using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public float runspeed;
    public float walkspeed;
    bool running;
    Rigidbody myRB;
    Animator myanim;
    bool rolate;
    //jump
    bool grounded = false;
    Collider[] groundCollisions;
    float checkradius = 0.2f;
    public LayerMask groundlayer;
    public Transform groundcheck;
    public float jumpheight;

	void Start () {
        myRB = GetComponent<Rigidbody>();
        myanim = GetComponent<Animator>();
        rolate = true;
	}
	
	
    void FixedUpdate()
    {
        running = false;

        if(grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myanim.SetBool("grounded", grounded);
            myRB.velocity = new Vector3(myRB.velocity.x, 0, 0);
            myRB.AddForce(new Vector3(0, jumpheight, 0));
        }
        groundCollisions = Physics.OverlapSphere(groundcheck.position, checkradius, groundlayer);
        if (groundCollisions.Length > 0) grounded = true;
        else grounded = false;
        myanim.SetBool("grounded", grounded);
        myanim.SetFloat("verticalspeed", myRB.velocity.y);


        float dichuyen = Input.GetAxis("Horizontal");
        myanim.SetFloat("speed", Mathf.Abs(dichuyen));
        float sneak = Input.GetAxisRaw("Fire3");
        myanim.SetFloat("sneak", sneak);

        float fire = Input.GetAxis("Fire1");
        myanim.SetFloat("shooting", fire);
        if ((sneak > 0 || fire>0) && grounded)
        {
           

            myRB.velocity = new Vector3(dichuyen * walkspeed, myRB.velocity.y, 0);
        }
        else
        {
            myRB.velocity = new Vector3(dichuyen * runspeed, myRB.velocity.y, 0);
            if(Mathf.Abs(dichuyen)>0) running = true;
        }


        if (dichuyen > 0 && !rolate) Flip();
        else if (dichuyen < 0 && rolate) Flip();

       
    }
    void Flip()
    {
        rolate = !rolate;
        Vector3 scale = transform.localScale;
        scale.z *= -1;
        transform.localScale = scale;
    }
    public float facing()
    {
        if (rolate) return 1f;
        else return -1f;
    }
    public bool getrunning()
    {
        return (running);
       
    }
    
}
