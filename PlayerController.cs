using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Anim
{
    public AnimationClip idle;
    public AnimationClip runForward;
    public AnimationClip runBackward;
    public AnimationClip runRight;
    public AnimationClip runLeft;
}

public class PlayerController : MonoBehaviour
{
    // variables for transform
    private float h = 0.0f;
    private float v = 0.0f;
    private Transform tr;
    public float moveSpeedH = 15.0f;
    public float moveSpeedV = 12.0f;
    public float rotSpeed = 50.0f;

    // animation configuration class for inspector view
    public Anim anim;

    // animation component object 
    public Animation _animation;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();

        // search and assigh animation component to variable
        _animation = GetComponentInChildren<Animation>();

        // save and play animation
        _animation.clip = anim.idle;
        _animation.Play();
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
        // tr.Rotate(Vector3.left * Time.deltaTime * rotSpeed * 0.2f * Input.GetAxis("Mouse Y"));

        if (v >= 0.1f)
        {
            // switch animation to forward smoothly
            _animation.CrossFade(anim.runForward.name, 0.3f);
        }
        else if (v <= -0.1f)
        {
            // switch animation to forward smoothly
            _animation.CrossFade(anim.runBackward.name, 0.3f);
        }
        else if (h >= 0.1f)
        {
            // switch animation to forward smoothly
            _animation.CrossFade(anim.runRight.name, 0.3f);
        }
        else if (h <= -0.1f)
        {
            // switch animation to forward smoothly
            _animation.CrossFade(anim.runLeft.name, 0.3f);
        }
        else
        {
            _animation.CrossFade(anim.idle.name, 0.3f);
        }
    }
}
