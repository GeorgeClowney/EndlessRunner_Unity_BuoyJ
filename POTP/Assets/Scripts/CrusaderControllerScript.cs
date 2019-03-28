using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//JacobBuoy 2019
//This is the player state machine controller script
public class CrusaderControllerScript : MonoBehaviour
{
    public Animator CrusaderController;
    PlayerRun playerRef;
    // Start is called before the first frame update
    void Start()
    {
        CrusaderController = this.gameObject.GetComponent<Animator>();
        playerRef = GameObject.Find("Player").GetComponent<PlayerRun>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!playerRef.isGrounded)
        {
            CrusaderController.SetBool("isJumping", true);
        }
        if (Input.GetMouseButtonDown(0) && playerRef.isGrounded && !playerRef.isAttacking )
        {
            CrusaderController.SetTrigger("isAttacking");
            playerRef.isAttacking = true;    
        }
        if (playerRef.isGrounded)
        {
            CrusaderController.SetBool("isJumping", false);
        }
        if (playerRef.isDead)
        {
            CrusaderController.SetBool("isDead", true);
        }
        if (playerRef.isGoodDead)
        {
            CrusaderController.SetBool("isGoodDead", true);
        }  
        if (playerRef.karma <= .3)
        {
            CrusaderController.SetBool("isBad", true);
            CrusaderController.SetBool("isNormal", false);
        }
        else
        {
            if (playerRef.karma >= .3 || playerRef.karma <= .7)
            {
                CrusaderController.SetBool("isNormal", true);
                CrusaderController.SetBool("isGood", false);
                CrusaderController.SetBool("isBad", false);
            }
        }
        if (playerRef.karma >= .7)
        {
            CrusaderController.SetBool("isGood", true);
            CrusaderController.SetBool("isBad", false);
            CrusaderController.SetBool("isNormal", false);
        }
    }
}

