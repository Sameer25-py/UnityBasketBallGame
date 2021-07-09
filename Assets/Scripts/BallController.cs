using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rb;
    public GameObject Player;
    public GameObject Ref;
    public bool active;
    public float height = 40;
    public float factor = 0f;
    public bool incordec = true;
    public float startTime = 0f;
    public float endTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
         rb = gameObject.GetComponent<Rigidbody>();
        
    }

    Vector3 GetVelocity()
    {
        Vector3 disp = Ref.transform.position - rb.transform.position;
        float dispY = disp.y;
        factor = Mathf.Abs(Time.time - startTime);
        
        if(factor > 1f) disp += Vector3.forward * 150.0f;
        else if(factor < 0.5f) disp += Vector3.forward * -50.0f;


        float gravity = Physics.gravity.y;
        Vector3 dispXZ = (Vector3.right * disp.x) + (Vector3.forward * disp.z);

        Vector3 yVelocity = Vector3.up * Mathf.Sqrt(-2 * gravity * height);
        Vector3 xzVelocity = dispXZ / (Mathf.Sqrt( (-2 * height)/ gravity) + Mathf.Sqrt( (2* (dispY - height)) / gravity));

        factor = 0f;
        startTime = 0f;
        return (yVelocity + xzVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        active = Player.GetComponent<MovementController>().active;
        if (active)
        {
            if (Input.GetKeyDown("e") || Input.GetButtonDown("Fire2"))
            {
                startTime = Time.time;
            }
            else if (Input.GetKeyUp("e") || Input.GetButtonUp("Fire2"))
            {
                gameObject.transform.parent = null;
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                rb.velocity = GetVelocity();
                Player.GetComponent<MovementController>().active = false;

            }
        }

        


       
    }
}
