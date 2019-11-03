using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float h = 0.0f;
    private float v = 0.0f;
    private Transform tr;
    public float moveSpeedH = 10.0f;
    public float moveSpeedV = 10.0f;
    public float rotSpeed = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Debug.Log("H=" + h.ToString());
        Debug.Log("V=" + v.ToString());
        Debug.Log("forward: " + Vector3.forward.ToString() + "  right: " + Vector3.right.ToString() + "  up: " + Vector3.up.ToString());
        Vector3 Direction = Vector3.forward * moveSpeedV * v + Vector3.right * moveSpeedH * h;
        tr.Translate(Direction.normalized * Time.deltaTime, Space.Self);
        tr.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X"));
    }
}
