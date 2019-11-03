using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform targetTr;  // transform information of target to be followed by camera 
    public float dist = 10.0f;  // distance between camera and target
    public float height = 3.0f;  // height of camera
    public float dampTrace = 20.0f;  // variable to guarantee smooth tracing
    // public float lerpVar = 0.5f;

    private Transform tr;  //  transform information of camera 

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // LateUpdate Function will be called after Update Function called 
    // this function will be called after player object finished transforming
    private void LateUpdate()
    {
        // put camera behind player object with value of variable "dist"
        // and pull up camera with value of variable "height"
        // third variable of lerp function will eventually become 1 after player moved, and it started with Time.deltaTime * dampTrace
        // Time.deltaTime * dampTrace defines a speed of moving from source position to target position
        // calculation is : source += (target - source) * speed [source and target are Vector3 and speed is third variable in lerp function]
        tr.position = Vector3.Lerp(tr.position, 
                                    targetTr.position - (targetTr.forward * dist) + (Vector3.up * height),
                                    Time.deltaTime * dampTrace);
        Debug.Log("camera position: " + tr.position.ToString());
        Debug.Log("player position: " + targetTr.position.ToString());
        // let camera look at player object
        tr.LookAt(targetTr.position);
    }
}
