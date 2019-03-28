using UnityEngine;
using System.Collections;
//JacobBuoy 2019
//This script runs the attack vfx
public class Shooting: MonoBehaviour
{  
    public GameObject Bullet_Emitter;
    public GameObject Bullet;
    PlayerRun playerRef;
    public float Bullet_Forward_Force;
    void Start()
    {
        playerRef = GameObject.Find("Player").GetComponent<PlayerRun>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && !playerRef.isAttacking && playerRef.karma < .3)
        {
            playerRef.fireball = true;
            GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
            SceneController.bullets.Add(Temporary_Bullet_Handler);
            Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();     
            Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);
        }
    }
}