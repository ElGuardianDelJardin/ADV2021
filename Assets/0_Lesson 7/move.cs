using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Animator anim;
    public float speed;
    public float turn;
    public float maxSpeed;

    public float StopVelocityForce;

    Vector3 localVelocity;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        localVelocity.z = gameObject.GetComponent<Rigidbody>().velocity.z;
        localVelocity.y = gameObject.GetComponent<Rigidbody>().velocity.y;
        localVelocity.x = gameObject.GetComponent<Rigidbody>().velocity.x - StopVelocityForce;

        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        localVelocity = rb.transform.InverseTransformDirection(rb.velocity);
        localVelocity.x *= 0.5f; // cut sideways speed in half
        rb.velocity = rb.transform.TransformDirection(localVelocity);


        if (Mathf.Abs(localVelocity.z) < maxSpeed)
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0 ,Input.GetAxis("Vertical")) * speed);
        gameObject.transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal"), 0 ) * turn);

        anim.SetFloat("Blend", (Input.GetAxis("Vertical") + 1) / 2);
        anim.speed = Mathf.Abs(localVelocity.z) / 20;
    }
}
