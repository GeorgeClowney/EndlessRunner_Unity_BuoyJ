using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//JacobBuoy 2019
//This is the main script for the game


public class PlayerRun : MonoBehaviour
{
    public AudioClip Sword; //All sounds are called from this script
    public AudioClip NormalDeath;
    public AudioClip GoodDeath;
    public AudioClip BadDeath;
    public AudioClip Kill;
    public AudioClip Fireball;
    public AudioSource soundEffect;
    public bool gameHasStarted = false; // Resets the game
    public bool fireball = false;
    public bool gameIsPaused = false;
    public bool killed = false;
    public float speed = 10;
    public float normSpeed = 10;
    public Vector3 jump;
    public float jumpForce = 2;
    public bool isGrounded = true;
    public bool hasExtraJump = false;
    public bool isDead = false;
    public bool isGoodDead = false;
    public bool isBadDead = false;
    public bool isAttacking = false;
    private int lane = 1;
    private bool doOnce = false;
    public int hp = 6;
    public int score;
    private float attkCount = 0;
    public float karma;
    private float time;
    public int devotionMode = -1;
    public Transform ringPos; //The vfx ring over the player.
    public GameObject bRing;
    public GameObject nRing;
    public GameObject gRing;
    GameObject ring;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        rb = GetComponent<Rigidbody>();
        karma = 0.5f; 
        ringPos = GameObject.Find("RingPos").GetComponent<Transform>();   
    }
    // Update is called once per frame
    void Update()
    { 
        if (gameHasStarted)
        {
            rb.useGravity = true; //Player does not fall through the stage
        }
        if (time > 10) //speed up the game every 10 secends
        {
            speed += 2;
            time -= 10;
        }
        if (!isDead && gameHasStarted && !gameIsPaused) // if the game is running
        {
            if (fireball)
            {
                soundEffect.PlayOneShot(Fireball, 1);
                fireball = false;
            }
            if (killed)
            {
                soundEffect.PlayOneShot(Kill, 4);
                killed = false;
            }
            if (hp <= 0)
            {
                soundEffect.PlayOneShot(NormalDeath, 1);
                isDead = true;
            }
            if (karma >= 1)
            {
                soundEffect.PlayOneShot(GoodDeath, 1);
                isDead = true;

            }
            if (karma <= 0)
            {
                soundEffect.PlayOneShot(BadDeath, 1);
                isDead = true;

            }
            score += (int)(10 * (speed / normSpeed));
            if (karma <= .3)  //Switchs between the three states
            {
                if (devotionMode != 0)
                {
                    Destroy(ring);
                    ring = Instantiate(bRing, ringPos.position, Quaternion.Euler(90, 0, 0));
                    devotionMode = 0;
                }
            }
            else if (karma >= .7) //Switchs between the three states
            {
                if (devotionMode != 2)
                {
                    Destroy(ring);
                    ring = Instantiate(gRing, ringPos.position, Quaternion.Euler(90, 0, 0));
                    devotionMode = 2;
                }
            }
            else if (karma > .3 && karma < .7) //Switchs between the three states
            {
                if (devotionMode != 1)
                {
                    Destroy(ring);
                    ring = Instantiate(nRing, ringPos.position, Quaternion.Euler(90, 0, 0));
                    devotionMode = 1;
                }
            }
            if (karma > .5f)
            {
                karma += .00035f;
            }
            else if (karma < .5f)
            {
                karma -= .00035f;
            }
            if (isAttacking) //Placeholder collision if the AABB misses it (it happens every now and then)
            {
                attkCount += Time.deltaTime;
                if (attkCount >= 1)
                {
                    soundEffect.PlayOneShot(Sword, 1);
                    attkCount = 0;
                    isAttacking = false;
                }
            }
            //Move the player and the ring above them forward
            Vector3 pos = ringPos.position;
            ring.transform.position = pos;
            pos = transform.position;
            pos.z += speed * Time.deltaTime;
            transform.position = pos;  
            //Jumping code
            if (isGrounded)
            {
                if (Input.GetButtonDown("Jump") && !doOnce && !(karma <= .3f))
                {
                    rb.velocity = Vector3.up * jumpForce;
                    isGrounded = false;
                }
                if (Input.GetButtonDown("Up") && (lane == 2 || lane == 1))
                {
                   
                    lane--;
                    rb.velocity = Vector3.left * 5;
                    doOnce = true;

                }
                if (Input.GetButtonDown("Down") && (lane == 0 || lane == 1))
                {
                    lane++;
                    rb.velocity = Vector3.right * 5;
                    doOnce = true;
                }
            }
            else if (karma >= .7f && hasExtraJump)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    rb.velocity = Vector3.up * jumpForce;
                    hasExtraJump = false;
                }

            }
            if (rb.velocity.y <= 0)
            {
                if (rb.velocity.y == 0)
                {
                    isGrounded = true;
                    hasExtraJump = true;
                }
            }
            if (!doOnce && isGrounded)
            {
                rb.velocity *= 0;
            }
            if (lane == 0 && pos.x < -1 && doOnce)
            {
                rb.velocity *= 0;
                pos.Set(-1, pos.y, pos.z);
                doOnce = false;
            }
            if (lane == 1 && (pos.x > -.05 && pos.x < .05) && doOnce)
            {
                rb.velocity *= 0;
                pos.Set(0, pos.y, pos.z);
                doOnce = false;
                doOnce = false;
            }
            if (lane == 2 && pos.x > 1 && doOnce)
            {
                rb.velocity *= 0; 
                pos.Set(1, pos.y, pos.z);
                doOnce = false;
            }
        }
    }
    //Restarts the game 
    public void Reset()
    {
  	  	gameHasStarted = false;
  		gameIsPaused = false;
   		rb.useGravity = false;
  		isGrounded = true;
    	hasExtraJump = false;
    	isDead = false;
    	isGoodDead = false;
    	isBadDead = false;
    	isAttacking = false;
    	lane = 1;
    	doOnce = false;
    	hp = 6;
    	score = 0;
    	attkCount = 0;
    	karma = .5f;
        speed = 10;
        time = 0.0f;
        devotionMode = -1;
}
}





