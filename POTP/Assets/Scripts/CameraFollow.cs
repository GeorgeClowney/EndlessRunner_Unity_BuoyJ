using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//JacobBuoy 2019
//This script tells the camera to follow the player target
public class CameraFollow : MonoBehaviour
{

    public Transform target;
    Vector3 tempVec3 = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame the target moves the camera 
    void LateUpdate()
    {
      
       transform.position = target.position;
        tempVec3.z = this.transform.position.z;
        this.transform.position = tempVec3;
    }
}
